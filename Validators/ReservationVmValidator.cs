using BikeRental.ViewModels;
using FluentValidation;

namespace BikeRental.Validators
{
    public class ReservationVmValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationVmValidator() 
        {
            RuleFor(x => x.ReservationStart)
                .NotEmpty().WithMessage("Podaj datę rozpoczęcia rezerwacji.")
                .GreaterThan(DateTime.Now).WithMessage("Data nie może być wcześniejsza, niż aktualna.")
                .LessThan(y => y.ReservationEnd).WithMessage("Data rozpoczęcia rezerwacji musi być datą wcześniejszą, niż data zakończenia.");

            RuleFor(x => x.ReservationEnd)
                .NotEmpty().WithMessage("Podaj datę zakończenia rezerwacji.")
                .GreaterThan(y => y.ReservationStart).WithMessage("Data zakończenia rezerwacji musi być datą późniejsza, niż data jej rozpoczęcia.")
                .GreaterThan(DateTime.Now).WithMessage("Data nie może być wcześniejsza, niż aktualna.");
        }

    }
}
