using Notebook.Core.Interfaces;

namespace Notebook.Core
{
    public class Note<T> : IEntity<T>
    {
        public T Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public Adres Adres { get; set; }
        public string Description { get; set; }

        object IEntity.Id { get => this.Id; set => throw new System.NotImplementedException(); }
    }
}