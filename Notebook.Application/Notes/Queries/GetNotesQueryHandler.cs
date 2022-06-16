using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notebook.Application.Core;
using Notebook.Application.DTOs;
using Notebook.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.Notes.Queries
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, Result<IEnumerable<NoteDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetNotesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<NoteDto>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = this.unitOfWork.NotesRepository.GetQuery().Include(note => note.Address);
            var response = this.mapper.Map<IEnumerable<NoteDto>>(notes);
            return Result<IEnumerable<NoteDto>>.Success(response);
        }
    }
}