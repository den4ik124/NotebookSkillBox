using Notebook.Application.DTOs;
using Notebook.Application.Notes.Commands;
using Notebook.Core;
using Shouldly;
using System.Threading;
using Xunit;

namespace Notebook.Tests.HandlersTests
{
    public class CreateNoteCommandHandlerTest : NotesBaseTest
    {
        [Fact]
        public async void CreateNoteCommandHandler_ShouldIncrease_NotesCount()
        {
            var genRepoMock = Mocks.MockRepository.GetMockedNoteRepository();
            UnitOfWorkMock.Setup(x => x.GetGenericRepository<Note>()).Returns(genRepoMock.Object);

            var itemsCountBefore = await genRepoMock.Object.GetItemsCount();
            //Arrange
            var handler = new CreateNoteCommandHandler(UnitOfWorkMock.Object, Mapper);

            var request = new CreateNoteCommand()
            {
                NoteDto = new NoteDto()
                {
                    FirstName = "Test name note creation",
                    LastName = "Test last name note creation",
                    ThirdName = "Test third name note creation",
                    Description = "Test description note creation",
                    PhoneNumber = "Test phone number note creation",
                    Address = null
                }
            };

            //Act
            var result = await handler.Handle(request, CancellationToken.None);
            var itemsCountAter = await genRepoMock.Object.GetItemsCount();

            //Assert
            result.IsSuccess.ShouldBeTrue();
            itemsCountAter.ShouldBe(itemsCountBefore + 1);
        }
    }
}