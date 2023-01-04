using System.ComponentModel.DataAnnotations;

namespace DelabinService.DTOs
{
    public class UpdateDocumentDto
    {
        [Required(ErrorMessage = "tags is required")]
        public string tags { get; set; }
    }
}
