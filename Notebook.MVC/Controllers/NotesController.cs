using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notebook.Application.Core;
using Notebook.Application.DTOs.Common;
using Notebook.Application.Notes.Queries;
using System.Threading.Tasks;

namespace Notebook.MVC.Controllers
{
    public class NotesController : BaseMVCController
    {
        private readonly IMapper mapper;

        public NotesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IActionResult> NotesList(/*[FromBody] PagingFilteringDto filteringData*/)
        {
            var filteringData = new PagingFilteringDto()
            {
                PageInfo = new PageInfo()
                {
                    Page = 1,
                    Size = 5
                },
            };

            //var mediatorResult = await this.Mediator.Send(new GetNotesQuery() { PageParameters = filteringData.PageInfo });
            //mediatorResult.Value.Items = this.mapper.Map<IEnumerable<NoteDto>>(mediatorResult.Value.Items);
            //var result = HandleResult(mediatorResult);
            var result = await this.Mediator.Send(new GetNotesQuery() { PageParameters = filteringData.PageInfo });

            if (result.IsSuccess)
            {
                return View(result.Value);
            }
            return View();
        }
    }
}