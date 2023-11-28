using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(i=>i.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(i=>i.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(i=>i.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");

            RuleFor(i => i.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(i => i.Surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(i => i.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            
            RuleFor(i => i.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz");
            RuleFor(i => i.Surname).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");
            RuleFor(i => i.City).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz");

        }
    }
}
