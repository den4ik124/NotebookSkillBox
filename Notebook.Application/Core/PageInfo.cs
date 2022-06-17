using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.Core
{
    public class PageInfo
    {
        [Required]
        public int Page { get; set; } = 1;

        public long Items { get; set; }

        [Required]
        public int Size { get; set; } = 10;
    }
}