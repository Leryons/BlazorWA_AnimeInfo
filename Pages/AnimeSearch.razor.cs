namespace AnimeInfo.Pages;

public partial class AnimeSearch
{
    [Inject]
    public AnimeServices? AnimeServices { get; set; }

    private string searchQuery = string.Empty;

    public Anime? animeSelected = null;

    private async Task OnSearch(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && searchQuery != null)
        {
            animeSelected = await AnimeServices!.GetAnimeByTitle(searchQuery) ?? new Anime();
        }
    }

    private async Task SearchButtonClicked()
    {
        if (searchQuery != null)
        {
            animeSelected = await AnimeServices!.GetAnimeByTitle(searchQuery) ?? new Anime();
        }
    }
}
