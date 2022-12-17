namespace BuberDinner.Contracts
{
    public record CreateMenuRequest(
        string Name,
        string Description,
        List<MenuSection> Sections
        );

    public record MenuSection(
        string Name,
        string Description,
        List<MenuItem> Items
        );

    public record MenuItem(
        string Name,
        string Description
        );
    
    public record MenuResponse(
        string Name,
        string Description,
        string HostId,
        decimal? AverageRating,
        DateTimeOffset CreatedDateTime,
        DateTimeOffset UpdatedDateTime,
        List<MenuSectionResponse> Sections
        );

    public record MenuSectionResponse(
        string Name,
        string Description,
        List<MenuItemResponse> Items
        );

    public record MenuItemResponse(
        string Name,
        string Description
        );
}
