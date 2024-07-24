using weddingApp.Model.Entities;

namespace weddingApp.Model.DTO_s
{
    public record ThingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
