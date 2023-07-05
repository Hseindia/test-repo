using System.Data;
using System.Data.SqlClient;

namespace WebApplication6.Models
{
    public class DAL
    {
        public SqlConnection con;
        public SqlCommand com;
        public SqlDataReader reader;
        public SqlDataAdapter adapter;
        public bool findMeeting(string idmeet)
        {
            con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
            com = new SqlCommand("select count(*) from meetings where idmeeting=@a", con);

            com.Parameters.AddWithValue("@a", idmeet);

            con.Open();

            int nb = int.Parse(com.ExecuteScalar().ToString());

            con.Close();
            if (nb == 0) { return false; }
            else { return true; }
        }

        public void addMeeting(string idmeeting, string name, int price)
        {
            if (findMeeting(idmeeting) == false)
            {
                con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
                com = new SqlCommand("insert into meetings values(@a, @b, @c)", con);

                com.Parameters.AddWithValue("@a", idmeeting);
                com.Parameters.AddWithValue("@b", name);
                com.Parameters.AddWithValue("@c", price);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            else { }
        }

        public void calculatePrice()
        {
            con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
            com = new SqlCommand("select sum(price) from meetings", con);



            con.Open();

            int nb = int.Parse(com.ExecuteScalar().ToString());

            con.Close();
       
        }

        public DataSet findMeetings()
        {
            con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
            com = new SqlCommand("select * from meetings", con);
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(com);

            adapter.Fill(ds, "M");
            return ds;
        }

        public Student getStudent(int id)
        {
            Student s = new Student();
            con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
            com = new SqlCommand("select * from Students where idstudent=@a", con);
            com.Parameters.AddWithValue("@a", id);

            con.Open();

            reader = com.ExecuteReader();
            while (reader.Read())
            {
                s = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

            }
            con.Close();

            return s;

        }
        public List<Student> findStudents()
        {
            List<Student> ls = new List<Student>();
            con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
            com = new SqlCommand("select * from Students", con);

            con.Open();

            reader = com.ExecuteReader();
            while (reader.Read())
            {
                Student s = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                ls.Add(s);
            }
            con.Close();

            return ls;
        }
        public List<Meeting> findM()
        {
            List<Meeting> ls = new List<Meeting>();
            con = new SqlConnection("Data Source =.; Initial Catalog = Revision; Integrated Security = True");
            com = new SqlCommand("select * from meetings", con);

            con.Open();

            reader = com.ExecuteReader();
            while (reader.Read())
            {
                Meeting m = new Meeting(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                ls.Add(m);
            }
            con.Close();

            return ls;
        }
    }
}
