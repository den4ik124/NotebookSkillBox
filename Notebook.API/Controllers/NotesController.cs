using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notebook.Application.DTOs;
using Notebook.Application.DTOs.Common;
using Notebook.Application.Notes.Commands;
using Notebook.Application.Notes.Queries;
using Notebook.Core.Constants;
using System.Threading.Tasks;

namespace Notebook.API.Controllers
{
    [Authorize(Policy = nameof(Policies.CustomerAccess))]
    public class NotesController : BaseApiController
    {
        [HttpPost("notes")]
        public async Task<IActionResult> GetNotes([FromBody] PagingFilteringDto filteringData)
        {
            return HandleResult(await this.Mediator.Send(new GetNotesQuery() { PageParameters = filteringData.PageInfo }));
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            return HandleResult(await Mediator.Send(new GetNoteByIdQuery()
            {
                NoteId = id
            }));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewNote(NoteDto newNoteData)
        {
            return HandleResult(await this.Mediator.Send(new CreateNoteCommand() { NoteDto = newNoteData }));
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditNote(NoteDto editedNote)
        {
            return HandleResult(await Mediator.Send(new EditNoteCommand()
            {
                EditedNote = editedNote
            }));
        }

        [Authorize(Policy = nameof(Policies.ManagerAccess))]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteNoteCommand()
            {
                NoteId = id
            }));
        }
    }
}