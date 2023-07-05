namespace WebApplication6.Models
{
    public class Student
    {
        public int idstudent { get; set; }
        public string namestudent { get; set; }

        public string idmeet { get; set; }

        public Student(int idstudent, string namestudent, string idmeet)
        {
            this.idstudent = idstudent;
            this.namestudent = namestudent;
            this.idmeet = idmeet;
        }

        public Student() { }
    }

}
