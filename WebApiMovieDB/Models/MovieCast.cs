namespace WebApiMovieDB.Models
{
    public partial class MovieCast
    {
        public int? ActorId { get; set; }
        public int? MovieId { get; set; }
        public string MovieRole { get; set; }
    }
}
