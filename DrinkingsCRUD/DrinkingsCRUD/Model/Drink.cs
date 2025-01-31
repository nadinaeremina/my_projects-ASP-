namespace DrinkingsCRUD.Model
{
    public class Drink
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public bool IsHot { get; set; }
        public Drink() {}
    }
}
