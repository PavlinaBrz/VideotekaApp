namespace VideotekaApp.Models
{
    public class UserRanking
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int FilmID { get; set; }
        public int Position { get; set; }
        public Film Film { get; set; }
    }
}
