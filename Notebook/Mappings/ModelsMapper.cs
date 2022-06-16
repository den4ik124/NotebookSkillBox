using AutoMapper;
using Notebook.Application.DTOs;
using Notebook.Core;

namespace Notebook.Mappings
{
    public class ModelsMapper : Profile
    {
        public ModelsMapper()
        {
            CreateMap<Note<int>, NoteDto>();
            CreateMap<NoteDto, Note<int>>();

            CreateMap<Adres, AdresDto>();
            CreateMap<AdresDto, Adres>();
        }
    }
}