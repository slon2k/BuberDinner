namespace BuberDinner.Contracts
{
    public record CreateMenuRequest(
        string Name,
        string Description,
        List<MenuSectionRequest> Sections
        );

    public record MenuSectionRequest(
        string Name,
        string Description,
        List<MenuItemRequest> Items
        );

    public record MenuItemRequest(
        string Name,
        string Description
        );
    
    public record MenuResponse(
        string Id,
        string Name,
        string Description,
        string HostId,
        decimal? AverageRating,
        DateTimeOffset CreatedDateTime,
        DateTimeOffset UpdatedDateTime,
        List<MenuSectionResponse> Sections
        );

    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items
        );

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description
        );
}
