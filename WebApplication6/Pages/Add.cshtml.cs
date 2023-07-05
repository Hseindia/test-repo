using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication6.Models;

namespace WebApplication6.Pages
{
    public class AddModel : PageModel
    {
        public List<Meeting> MeetingList { get; set; }
        public void OnGet()
        {
            MeetingList = new List<Meeting>();
            MeetingList = new DAL().findM();
        }
        public void OnPost() {
            //just insert the new meeting in the meetings table

            int idm = int.Parse(Request.Form["id"].ToString());
            string namem = Request.Form["name"];
            string meeting =Request.Form["meet"].ToString().Trim();

            Console.WriteLine(meeting + " ");
        }
    }
}
