using Microsoft.AspNetCore.Mvc;
using Notebook.Application.DTOs.Common;
using Notebook.Application.Notes.Queries;
using System.Threading.Tasks;

namespace Notebook.MVC.Controllers
{
    public class NotesController : BaseMVCController
    {
        public async Task<IActionResult> NotesList([FromBody] PagingFilteringDto filteringData)
        {
            var result = HandleResult(await this.Mediator.Send(new GetNotesQuery() { PageParameters = filteringData.PageInfo }));

            return View(result);
        }
    }
}