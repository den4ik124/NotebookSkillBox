using Microsoft.AspNetCore.Mvc;
using Notebook.Application.DTOs;
using Notebook.Application.Notes.Commands;
using Notebook.Application.Notes.Queries;
using System.Threading.Tasks;

namespace Notebook.Controllers
{
    public class NotesController : BaseApiController
    {
        // GET: api/<NotesController>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return HandleResult(await this.Mediator.Send(new GetNotesQuery()));
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<IActionResult> CreateNewNote(NoteDto newNoteData)
        {
            return HandleResult(await this.Mediator.Send(new CreateNoteCommand() { NoteDto = newNoteData }));
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}