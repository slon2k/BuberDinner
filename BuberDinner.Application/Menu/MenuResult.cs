namespace BuberDinner.Application.Menu
{
    public record MenuResult(
        string Name,
        string Description,
        string HostId,
        decimal? AverageRating,
        DateTimeOffset CreatedDateTime,
        DateTimeOffset UpdatedDateTime,
        List<MenuSectionResult> Sections
        );

    public record MenuSectionResult(
        string Name,
        string Description,
        List<MenuItemResult> Items
        );

    public record MenuItemResult(
        string Name,
        string Description
        );
}
