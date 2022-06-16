namespace Notebook.Core
{
    public class Note : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
    }
}