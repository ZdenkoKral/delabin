using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelabinService.Models
{
    [Table("Data")]
    public class DocData
    {
            [Key]
            public Guid id { get; set; }
            public string someData { get; set; }
            public string? fieldData { get; set; }

            [ForeignKey(nameof(Document))]
            public Guid Documentid { get; set; }
            public Document document { get; set; }
    }
}
