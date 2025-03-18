namespace CatsCRUD.Model
{
    public class Cat
    {
        public int Id { get; set; }
        public int Iid { get; set; } 
        public string Name { get; set; } = String.Empty;
        public string Image_link { get; set; }
        public int Age { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; } = String.Empty;
        public bool Favourite { get; set; }
        public Cat() { }
    }
}
