namespace Notebook.MVC.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressModel Address { get; set; }
        public string Description { get; set; }
    }
}