using BikeRental.ViewModels;
using FluentValidation;

namespace BikeRental.Validators
{
    public class RentalPointVmValidator : AbstractValidator<RentalPointViewModel>
    {
        public RentalPointVmValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Pole nie może być puste.")
                .MaximumLength(30).WithMessage("Nazwa nie może być dłuższa niż 30 znaków");
            RuleFor(x => x.Location) //TODO: replace with Address entity 
                .NotEmpty().WithMessage("Pole nie może być puste.");
            RuleFor(x => x.EmailAdress)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .EmailAddress().WithMessage("Pole musi zawierać poprawny format adresu email.");
            RuleFor(x => x.phoneNumber)
                .NotEmpty().WithMessage("Pole nie może być puste.")
                .Matches(@"^[0-9]*$").WithMessage("Numer telefonu może zawierać tylko cyfry")
                .Length(9).WithMessage("Numer telefonu musi zawierać dokładnie 9 znaków.");
                
        }
    }
}
