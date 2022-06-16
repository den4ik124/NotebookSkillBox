using MediatR;
using Notebook.Application.Core;
using Notebook.Application.DTOs;
using System.Collections.Generic;

namespace Notebook.Application.Notes.Queries
{
    public class GetNotesQuery : IRequest<Result<IEnumerable<NoteDto>>>
    {
    }
}