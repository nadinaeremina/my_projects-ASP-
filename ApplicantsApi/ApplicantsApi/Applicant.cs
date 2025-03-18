namespace ApplicantsApi
{
    // абитуриент - класс сущности
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly BirtDate { get; set; }
        public bool IsInternational { get; set; }
        public Applicant() { }
    }
}
