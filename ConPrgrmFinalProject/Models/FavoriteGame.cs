namespace ConPrgrmFinalProject.Models
{
    public class FavoriteGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public int HoursPlayed { get; set; }
        public bool IsMultiplayer { get; set; }
    }
}