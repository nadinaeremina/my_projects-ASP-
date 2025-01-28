namespace HomeworkCRUD.Model
{
    //класс, описываюший котика 
    public class Cat
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;
        public string Breed { get; set; } = String.Empty;
        public DateTime Birthday { get; set; }
        public int Rating { get; set; } 
        public decimal Price { get; set; } 
        public Cat() { }
    }
}
