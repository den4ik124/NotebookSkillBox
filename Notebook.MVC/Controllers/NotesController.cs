using Microsoft.AspNetCore.Mvc;
using Notebook.Application.Core;
using Notebook.Application.DTOs;
using Notebook.Application.DTOs.Common;
using Notebook.Application.Notes.Commands;
using Notebook.Application.Notes.Queries;
using System.Threading.Tasks;

namespace Notebook.MVC.Controllers
{
    public class NotesController : BaseMVCController
    {
        public async Task<IActionResult> NotesList([FromQuery] int currentPage)
        {
            if (currentPage == default)
            {
                currentPage = 1;
            }
            var filteringData = new PagingFilteringDto()
            {
                PageInfo = new PageInfo()
                {
                    Page = currentPage,
                    Size = 5
                },
            };

            return HandleResult(await this.Mediator.Send(new GetNotesQuery() { PageParameters = filteringData.PageInfo }));
        }

        public async Task<IActionResult> NoteData(int id)
        {
            return HandleResult(await Mediator.Send(new GetNoteByIdQuery()
            {
                NoteId = id
            }));
        }

        public async Task<IActionResult> DeleteNote(int id)
        {
            var result = await Mediator.Send(new DeleteNoteCommand()
            {
                NoteId = id
            });
            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(this.NotesList));
            }
            return View(result.Error);
        }

        public async Task<IActionResult> EditNote(int noteId)
        {
            var result = await Mediator.Send(new GetNoteByIdQuery()
            {
                NoteId = noteId
            });
            if (result.IsSuccess)
            {
                return View(result.Value);
            }
            return View(result.Error);
        }

        public async Task<IActionResult> EditNoteAction(NoteDto editedNote)
        {
            var result = await Mediator.Send(new EditNoteCommand()
            {
                EditedNote = editedNote
            });

            if (result.IsSuccess)
            {
                return Redirect($"NoteData/{editedNote.Id}");
            }

            return View(result.Error);
        }
    }
}