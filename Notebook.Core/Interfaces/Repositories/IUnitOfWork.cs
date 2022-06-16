using System.Threading.Tasks;

namespace Notebook.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : ITransaction
    {
        IRepository<Note<int>> NotesRepository { get; }

        Task<bool> CompleteAsync();
    }
}