using Moq;
using Notebook.Application.DTOs;
using Notebook.Application.Notes.Commands;
using Notebook.Core;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Notebook.Tests.HandlersTests
{
    public class EditNoteCommandHandlerTest : NotesBaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void EditNoteCommandHandler_ShouldUpdate_NoteData(int noteId)
        {
            var genRepoMock = Mocks.MockRepository.GetMockedNoteRepository();
            var items = new List<Note>()
            {
                new Note()
                {
                    Id = 1,
                    FirstName = "Name 1",
                    LastName = "Last Name 1",
                    ThirdName = "Third Name 1",
                    PhoneNumber = "phone number",
                    Description = "Description 1",
                    Address = new Address()
                    {
                        Id = 1,
                        Country = "Test County",
                        City = "Test City",
                        Street = "Test Street",
                        HouseNumber = 1,
                        Index = 11111
                    }
                },
                new Note()
                {
                    Id = 2,
                    FirstName = "Name 2",
                    LastName = "Last Name 2",
                    ThirdName = "Third Name 2",
                    PhoneNumber = "phone number",
                    Description = "Description 2",
                    Address = new Address()
                    {
                        Id = 2,
                        Country = "Test County",
                        City = "Test City",
                        Street = "Test Street",
                        HouseNumber = 2,
                        Index = 22222
                    }
                },
                new Note()
                {
                    Id = 3,
                    FirstName = "Name 3",
                    LastName = "Last Name 3",
                    ThirdName = "Third Name 3",
                    PhoneNumber = "phone number",
                    Description = "Description 3",
                    Address = new Address()
                    {
                        Id = 3,
                        Country = "Test County",
                        City = "Test City",
                        Street = "Test Street",
                        HouseNumber = 3,
                        Index = 33333
                    }
                },
            };

            genRepoMock.Setup(rep => rep.Update(It.IsAny<Note>())).Returns((Note updatedItem) =>
            {
                var item = items.FirstOrDefault(i => i.Id == noteId);
                item = updatedItem;
                return true;
            });
            UnitOfWorkMock.Setup(x => x.GetGenericRepository<Note>()).Returns(genRepoMock.Object);
            var editedNote = (await genRepoMock.Object.GetWhere(x => x.Id == noteId)).FirstOrDefault();
            var checkString = "changed property";

            var editedNoteDto = new NoteDto();
            Mapper.Map(editedNote, editedNoteDto);

            editedNoteDto.FirstName = checkString;
            editedNoteDto.LastName = checkString;
            editedNoteDto.ThirdName = checkString;

            //Arrange
            var handler = new EditNoteCommandHandler(UnitOfWorkMock.Object, Mapper);

            var request = new EditNoteCommand()
            {
                EditedNote = editedNoteDto,
            };

            //Act
            var result = await handler.Handle(request, CancellationToken.None);
            var changedNote = (await genRepoMock.Object.GetWhere(x => x.Id == noteId)).FirstOrDefault();

            //Assert
            result.IsSuccess.ShouldBeTrue();
            changedNote.FirstName.ShouldBe(checkString);
            changedNote.LastName.ShouldBe(checkString);
            changedNote.ThirdName.ShouldBe(checkString);
            //itemsCountAter.ShouldBe(itemsCountBefore - 1);
        }
    }
}