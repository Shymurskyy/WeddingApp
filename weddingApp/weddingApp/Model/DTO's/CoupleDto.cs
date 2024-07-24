namespace weddingApp.Model
{
    public record CoupleDto
    {
        public int Id { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public int WeddingEventId { get; set; }
    }
}
