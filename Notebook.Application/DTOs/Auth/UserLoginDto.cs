using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.Dto.Auth
{
    public class UserLoginDto
    {
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}