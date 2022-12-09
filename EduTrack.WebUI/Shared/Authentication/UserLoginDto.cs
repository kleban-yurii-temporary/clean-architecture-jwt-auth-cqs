
using System.ComponentModel.DataAnnotations;

namespace EduTrack.WebUI.Shared.Authentication
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    /*
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
        {
            public UserLoginDtoValidator()
            {
                RuleFor(customer => customer.Email).NotEmpty().EmailAddress().MaximumLength(50);
                RuleFor(customer => customer.Password).NotEmpty().MaximumLength(50);
            }
        }*/
    }