using AutoMapper;
using MediatR;
using Notebook.Application.Core;
using Notebook.Core;
using Notebook.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.Notes.Commands
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteModel = this.mapper.Map<Note>(request.NoteDto);
            if (await this.unitOfWork.NotesRepository.Add(noteModel))
            {
                await this.unitOfWork.CompleteAsync();
                return Result<string>.Success("Creation succeeded.");
            }
            return Result<string>.Failure("Creation failed.");
        }
    }
}