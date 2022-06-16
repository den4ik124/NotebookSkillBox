namespace Notebook.Application.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
        public string Description { get; set; }
    }
}