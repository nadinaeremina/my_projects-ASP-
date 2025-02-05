using CatsCRUD.Model;

namespace CatsCRUD.Messages
{
    public class StringData
    {
        public StringMessage StringMessage_ { get; set; } = new StringMessage();
        public HashSet<Cat>? Data { get; set; }
        public StringData() { }
    }
}
