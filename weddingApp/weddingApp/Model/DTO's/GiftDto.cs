namespace weddingApp.Model.DTO_s
{
    public record GiftDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPurchased { get; set; }
        public int WeddingEventId { get; set; }
    }
}
