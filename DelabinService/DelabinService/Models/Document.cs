using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelabinService.Models
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        public Guid id { get; set; }
        public string tags { get; set; }
        public ICollection<DocData>? data { get; set; }
    }
}
