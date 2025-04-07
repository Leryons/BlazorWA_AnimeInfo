namespace AnimeInfo.Pages;

public partial class AnimeList
{
    [Inject]
    public AnimeServices? AnimeServices { get; set; }

    private List<Anime>? animesList;

    protected override async Task OnInitializedAsync()
    {
        if (AnimeServices != null)
        {
            animesList = await AnimeServices.GetTopAnimes();
        }
        else
        {
            animesList = new List<Anime>();
        }
    }
}
