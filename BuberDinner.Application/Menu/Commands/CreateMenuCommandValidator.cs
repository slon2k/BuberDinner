using FluentValidation;

namespace BuberDinner.Application.Menu.Commands
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.HostId).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
        }
    }
}
