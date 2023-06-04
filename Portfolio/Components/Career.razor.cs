using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Services;

namespace Portfolio.Components;

public partial class Career
{
    [Inject]
    public IBreakpointService BreakpointListener { get; set; } = null!;

    public bool IsMobile { get; set; }
    public TimelinePosition TimelinePosition
        => IsMobile ? TimelinePosition.Left : TimelinePosition.Alternate;

    protected override async Task OnInitializedAsync()
    {
        await BreakpointListener.SubscribeAsync((breakpoint) =>
        {
            IsMobile = breakpoint == Breakpoint.Xs;
            StateHasChanged();
        });
    }
}
