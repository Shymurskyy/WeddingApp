namespace weddingApp.Model.DTO_s
{
    public record WeddingServiceDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public bool Done { get; set; }
        public ServiceDto Service { get; set; }
        public int WeddingEventId { get; set; }
    }
}
