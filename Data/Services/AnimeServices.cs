namespace AnimeInfo.Data.Services;

public class AnimeServices
{
    readonly HttpClient client = new();

    public async Task<List<Anime>> GetTopAnimes() // Get Top Animes. 
    {
        var response = await client.GetAsync("https://api.jikan.moe/v4/top/anime");

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(responseBody);

            var animeData = json["data"]?[0];

            if (animeData != null)
            {
                var animeList = new List<Anime>();
                foreach (var anime in json["data"])
                {
                    var animeItem = new Anime
                    {
                        Title = anime["title"]?.ToString(),
                        Synopsis = anime["synopsis"]?.ToString(),
                        Genre = anime["genres"]?[0]?["name"]?.ToString(),
                        ImageUrl = anime["images"]?["jpg"]?["image_url"]?.ToString(),
                        ReleaseDate = DateTime.Parse(anime["aired"]?["from"]?.ToString() ?? DateTime.MinValue.ToString()),
                        Rating = double.TryParse(anime["score"]?.ToString(), out var score) ? score : 0,
                        EpisodeCount = int.TryParse(anime["episodes"]?.ToString(), out var episodes) ? episodes : 0,
                        InfoUrl = anime["url"]?.ToString() ?? string.Empty
                    };
                    animeList.Add(animeItem);
                }
                return animeList;
            }
        }
        return null;
    }

    public async Task<Anime> GetAnimeByTitle(string title) // Get Anime by title. 
    {
        var response = await client.GetAsync($"https://api.jikan.moe/v4/anime?q={title}");
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);
            var animeData = json["data"]?[0];
            if (animeData != null)
            {
                var animeItem = new Anime
                {
                    Title = animeData["title"]?.ToString(),
                    Synopsis = animeData["synopsis"]?.ToString(),
                    Genre = animeData["genres"]?[0]?["name"]?.ToString(),
                    ImageUrl = animeData["images"]?["jpg"]?["image_url"]?.ToString(),
                    ReleaseDate = DateTime.Parse(animeData["aired"]?["from"]?.ToString() ?? DateTime.MinValue.ToString()),
                    Rating = double.TryParse(animeData["score"]?.ToString(), out var score) ? score : 0,
                    EpisodeCount = int.TryParse(animeData["episodes"]?.ToString(), out var episodes) ? episodes : 0,
                    InfoUrl = animeData["url"]?.ToString() ?? string.Empty
                };
                return animeItem;
            }
        }
        return null;
    }
}
