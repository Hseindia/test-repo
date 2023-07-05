using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication6.Models;
namespace WebApplication6.Pages
{
    public class SelectStudentModel : PageModel
    {
        public Student s;

        public void OnGet()
        {
            s = new Student();
            int idst = int.Parse(Request.Query["idst"]);
            s = new DAL().getStudent(idst);

        }

        public void OnPost() {
            s = new Student();

            Response.Redirect("Students");
        }
    }
}
