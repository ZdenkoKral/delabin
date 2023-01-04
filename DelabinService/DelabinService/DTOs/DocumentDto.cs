namespace DelabinService.DTOs
{
    public class DocumentDto
    {
        public Guid id { get; set; }
        public string tags { get; set; }
        public IEnumerable<DataDto>? data { get; set; }
    }
}
