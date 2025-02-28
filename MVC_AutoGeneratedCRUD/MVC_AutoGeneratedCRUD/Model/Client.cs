﻿namespace MVC_AutoGeneratedCRUD.Model
{
    // Client - класс, описывающий сущность клиента
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BirthYear { get; set; }
        public int BonusBalance { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public Client() { }
    }
}
