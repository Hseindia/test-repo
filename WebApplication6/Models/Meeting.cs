namespace WebApplication6.Models
{
    public class Meeting
    {
        public string idmeeting { get; set; }

        public string rpassword { get; set; }

        public int price { get; set; }

        public Meeting(string idmeeting, string rpassword, int price)
        {
            this.idmeeting = idmeeting;
            this.rpassword = rpassword;
            this.price = price;
        }

    }
}
