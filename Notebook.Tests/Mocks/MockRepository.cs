using Moq;
using Notebook.Core;
using Notebook.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Notebook.Tests.Mocks
{
    public static class MockRepository
    {
        public static Mock<IGenericRepository<Note>> GetMockedNoteRepository()
        {
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
            return RepositoryCreation(items);
        }

        private static Mock<IGenericRepository<T>> RepositoryCreation<T>(ICollection<T> items) where T : class
        {
            var mockRepo = new Mock<IGenericRepository<T>>();
            mockRepo.Setup(rep => rep.GetAll()).ReturnsAsync(items);

            mockRepo.Setup(rep => rep.Add(It.IsAny<T>())).ReturnsAsync((T item) =>
            {
                items.Add(item);
                return true;
            });

            mockRepo.Setup(rep => rep.GetWhere(It.IsAny<Expression<Func<T, bool>>>())).ReturnsAsync((Expression<Func<T, bool>> predicate) =>
            {
                return items.AsQueryable().Where(predicate).ToList();
            });

            mockRepo.Setup(rep => rep.GetItemsCount(It.IsAny<Expression<Func<T, bool>>>())).ReturnsAsync((Expression<Func<T, bool>> predicate) =>
            {
                if (predicate != null)
                {
                    return items.AsQueryable().Where(predicate).Count();
                }
                return items.Count;
            });

            mockRepo.Setup(rep => rep.GetQuery(It.IsAny<Expression<Func<T, bool>>>(), It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>()))
                .Returns((Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy) =>
                {
                    if (predicate != null)
                    {
                        return items.AsQueryable().Where(predicate);
                    }
                    return items.AsQueryable();
                });

            return mockRepo;
        }
    }
}