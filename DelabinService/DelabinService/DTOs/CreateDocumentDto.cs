using System.ComponentModel.DataAnnotations;

namespace DelabinService.DTOs
{
    public class CreateDocumentDto
    {
        [Required(ErrorMessage = "tags is required")]

        public string tags { get; set; }
    }
}
