using Microsoft.AspNetCore.Components;
using MudBlazor;
using Portfolio.Models;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

namespace Portfolio.Components;

public partial class Competence
{
    [Inject]
    public HttpClient Client { get; set; } = null!;

    public CompetenceModel[] Competences { get; set; } = Array.Empty<CompetenceModel>();

    public string? CategoryFilter { get; set; }
    public string? SearchInput { get; set; }
    public int RatingFilter { get; set; }
    public Color RatingFilterColour { get; set; } = Color.Warning;

    protected override async Task OnInitializedAsync()
    {
        Competences = await Client.GetFromJsonAsync<CompetenceModel[]>("/static/competences.json") ?? Array.Empty<CompetenceModel>();
        Competences = Competences.OrderByDescending(x => x.Rating).ThenByDescending(x => x.Category).ToArray();
    }
    private bool Filter(CompetenceModel element)
    {
        if (!String.IsNullOrWhiteSpace(CategoryFilter))
        {
            if (!element.Category.Equals(CategoryFilter, StringComparison.OrdinalIgnoreCase))
                return false;
        }

        if (!String.IsNullOrWhiteSpace(SearchInput))
        {
            if (element.Title.Contains(SearchInput, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.MoreInfo?.Contains(SearchInput, StringComparison.OrdinalIgnoreCase) ?? false)
                return true;
        }

        if (RatingFilter != 0)
        {
            if (element.Rating < RatingFilter)
                return false;
        }

        return true;
    }
    private Color DetermineColour(CompetenceModel element)
    {
        if(element.Rating >= 4)
        {
            return Color.Success;
        }
        else if(element.Rating == 3)
        {
            return Color.Warning;
        }
        else
        {
            return Color.Error;
        }
    }
    public void RatingFilterHover(int? rating)
    {
        if (rating >= 4)
        {
            RatingFilterColour = Color.Success;
        }
        else if (rating == 3)
        {
            RatingFilterColour = Color.Warning;
        }
        else if(rating <= 2)
        {
            RatingFilterColour = Color.Error;
        }
    }
}
