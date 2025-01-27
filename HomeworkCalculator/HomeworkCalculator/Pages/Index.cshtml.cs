using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeworkCalculator.Pages
{
    public class IndexModel : PageModel
    {
        public string App_name { get; private set; } = "Calculator App";
        public string H1_name { get; private set; } = "The Circle";
        public string Param { get; private set; } = String.Empty;       
        public string Issue { get; private set; } = String.Empty;
        public double Value { get; private set; }
        public double Result { get; private set; }
        public string? Error { get; private set; } = null; 
        public void OnGet(string param = "radius", string issue = "square", double value = 0)
        {
            Value = value;
            Param = param;
            Issue = issue;
            if (value < 0)
            {
                Error = "`value` must be more than 0";
                return;
            }
            Error = null;          
            Result = Calculation(param, issue, value);
        }
        private double Calculation(string param, string issue, double value = 1)
        {
            if (param == "radius") 
            {
                if (issue == "square")
                {
                    return Math.PI * value * value;
                }
                return 2 * Math.PI * value;
            }
            if (param == "diameter")
            {
                if (issue == "square")
                {
                    return value * value / 4 * Math.PI;
                }
                return Math.PI * value;
            }
            return 0;
        }
    }
}
