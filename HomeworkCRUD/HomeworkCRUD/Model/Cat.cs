namespace HomeworkCRUD.Model
{
    //класс, описываюший котика 
    public class Cat
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Behaviour { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;

        public Cat() { }

        public override string ToString()
        {
            return $"{Id} - {Nickname} - {Gender} - {Breed} - {Birthday} - {Behaviour} - {Price}";
        }
    }
}
