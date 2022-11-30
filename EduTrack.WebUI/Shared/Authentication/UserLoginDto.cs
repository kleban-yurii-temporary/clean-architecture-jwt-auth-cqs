using FluentValidation;

namespace EduTrack.WebUI.Shared.Authentication
{
    public class UserLoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
        {
            public UserLoginDtoValidator()
            {
                RuleFor(customer => customer.Email).NotEmpty().EmailAddress().MaximumLength(50);
                RuleFor(customer => customer.Password).NotEmpty().MaximumLength(50);
            }
        }
    }