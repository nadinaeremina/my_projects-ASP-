namespace ExamSquareEquation.Messages
{
    public class StringData
    {
        public int RootCount { get; set; } = 0;
        public double X1 { get; set; }
        public double X2 { get; set; }
        public Coefficient coefficients { get; set; } = new Coefficient();
        public StringData() { }
    }
}
