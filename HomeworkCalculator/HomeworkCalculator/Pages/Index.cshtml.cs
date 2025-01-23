using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeworkCalculator.Pages
{
    public class IndexModel : PageModel
    {
        public string Parametr { get; private set; }         
        public string Issue { get; private set; }     
        public double Value { get; private set; }     
        public double Result { get; private set; }
        public string? Error { get; private set; } = null; 
        double Pi { get; } = 3.14;
        public void OnGet(string parameter = "", string isuue = "", double value = 1)
        {
            Value = value;
            if (value < 0 || value > 20)
            {
                Error = "`value` must be in range [0; 20]";
                return;
            }
            if (parameter == "" || isuue == "")
            {
                Error = "`parametr` or `issue `must be selected";
                return;
            }
            Error = null;
            Parametr = parameter;
            Issue = isuue;
            Result = Calculation(parameter, isuue);
        }
        private double Calculation(string parameter, string isuue)
        {
            if (parameter == "radius") 
            {
                if (isuue == "square")
                {
                    return Pi *Value * Value;
                }
                return 2 * Pi * Value;
            }
            if (parameter == "diameter")
            {
                if (isuue == "square")
                {
                    return Value * Value / 4 * Pi;
                }
                return Pi * Value;
            }
            return 0;
        }
    }
}
