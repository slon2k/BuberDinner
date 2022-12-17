using BuberDinner.Application.Menu;
using BuberDinner.Application.Menu.Commands;
using BuberDinner.Contracts;
using BuberDinner.Domain.Menu;
using Mapster;

namespace BuberDinner.Api.Common.Mappings
{
    public class MenuMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.hostId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<MenuSectionRequest, CreateMenuSection>()
                .Map(dest => dest, src => src);

            config.NewConfig<MenuItemRequest, CreateMenuItem>()
                .Map(dest => dest, src => src);

            config.NewConfig<MenuEntity, MenuResponse>()
                .Map(dest => dest.HostId, src => src.HostId.ToString())
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest, src => src);

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest, src => src);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest, src => src);
        }
    }
}
