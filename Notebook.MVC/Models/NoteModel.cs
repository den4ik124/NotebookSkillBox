using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notebook.Application.DTOs;
using Notebook.MVC.Controllers;
using System.Threading.Tasks;

namespace Notebook.MVC.Models
{
    public class NoteModel : PageModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressModel Address { get; set; }
        public string Description { get; set; }

        //public Task<IActionResult> OnPost()
        //{
        //    var newNoteDto = new NoteDto()
        //    {
        //        Id = this.Id,
        //        FirstName = this.FirstName,
        //        LastName = this.LastName,
        //        ThirdName = this.ThirdName,
        //        PhoneNumber = this.PhoneNumber,
        //        Address = new AddressDto()
        //        {
        //            Id = this.Address.Id,
        //            Country = this.Address.Country,
        //            City = this.Address.City,
        //            Index = this.Address.Index,
        //            Street = this.Address.Street,
        //            HouseNumber = this.Address.HouseNumber,
        //        },
        //        Description = this.Description,
        //    };
        //    return new NotesController().CreateNoteAction(newNoteDto);
        //}
    }
}