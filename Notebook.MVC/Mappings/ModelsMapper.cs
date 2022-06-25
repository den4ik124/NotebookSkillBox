using AutoMapper;
using Notebook.Application.DTOs;
using Notebook.Core;
using Notebook.MVC.Models;

namespace Notebook.MVC.Mappings
{
    public class ModelsMapper : Profile
    {
        public ModelsMapper()
        {
            CreateMap<NoteModel, NoteDto>();
            CreateMap<NoteDto, NoteModel>();

            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
        }
    }
}