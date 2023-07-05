using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication6.Models; 

namespace WebApplication6.Pages
{
    public class StudentsModel : PageModel
    {
        public List<Student> Students { get; set; }
        public void OnGet()
        {
            Students = new List<Student>();
            Students = new DAL().findStudents();
        }
    }
}
