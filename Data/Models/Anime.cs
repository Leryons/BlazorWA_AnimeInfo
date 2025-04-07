namespace AnimeInfo.Data.Models;

public class Anime
{
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public double Rating { get; set; }
    public int EpisodeCount { get; set; }
    public string InfoUrl { get; set; } = string.Empty;
}
