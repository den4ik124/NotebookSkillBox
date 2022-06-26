using MediatR;
using Notebook.Application.Core;
using Notebook.Application.DTOs;

namespace Notebook.Application.Notes.Queries
{
    public class GetNoteByIdQuery : IRequest<Result<NoteDto>>
    {
        public int NoteId { get; set; }
    }
}