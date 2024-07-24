namespace weddingApp.Model.DTO_s
{
    public record ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeddingServiceId { get; set; }
    }
}
