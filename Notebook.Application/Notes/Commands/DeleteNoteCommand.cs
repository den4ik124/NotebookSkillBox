using MediatR;
using Notebook.Application.Core;

namespace Notebook.Application.Notes.Commands
{
    public class DeleteNoteCommand : IRequest<Result<string>>
    {
        public int NoteId { get; set; }
    }
}