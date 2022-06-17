﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notebook.Application.Core;
using Notebook.Application.DTOs;
using Notebook.Core;
using Notebook.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.Notes.Queries
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, Result<PagedList<NoteDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetNotesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<PagedList<NoteDto>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = GetItemsFromQuery(request);// this.unitOfWork.NotesRepository.GetQuery().Include(note => note.Address).Skip(offset).Take(request.PageParameters.Size);
            var response = this.mapper.Map<IEnumerable<NoteDto>>(notes);

            request.PageParameters.Items = await this.unitOfWork.NotesRepository.GetItemsCount();

            return Result<PagedList<NoteDto>>.Success(new PagedList<NoteDto>(response, request.PageParameters));
        }

        private IEnumerable<Note> GetItemsFromQuery(GetNotesQuery request,
                                                    Expression<Func<Note, bool>> predicate = null,
                                                    Func<IQueryable<Note>, IOrderedQueryable<Note>> orderBy = null)
        {
            var offset = (request.PageParameters.Page - 1) * request.PageParameters.Size;
            if (predicate != null)
            {
                return this.unitOfWork.NotesRepository.GetQuery(predicate, orderBy)
                                                      .Include(note => note.Address)
                                                      .Skip(offset)
                                                      .Take(request.PageParameters.Size);
            }
            return this.unitOfWork.NotesRepository.GetQuery(null, orderBy)
                                                  .Include(note => note.Address)
                                                  .Skip(offset)
                                                  .Take(request.PageParameters.Size);
        }
    }
}