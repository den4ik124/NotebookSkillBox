using AutoMapper;
using Notebook.Application.DTOs;
using Notebook.Core;

namespace Notebook.MVC.Mappings
{
    public class ModelsMapper : Profile
    {
        public ModelsMapper()
        {
            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
        }
    }
}