namespace RazorPagesSimpleCRUD.Model
{
    // Issue - класс, описываюший задачу в списке дел
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public bool Done { get; set; }

        public Issue() { }

        public override string ToString()
        {
            return $"{Id} - {Title}";
        }
    }
}
