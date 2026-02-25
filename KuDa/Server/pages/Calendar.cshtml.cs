using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace KuDa.Server.Pages
{
    public class CalendarModel : PageModel
    {
        private DateTime today;
        private DateTime firstDayOfMonth;
        private int weekRows;

        public void OnGet()
        {
        }
    }
}
