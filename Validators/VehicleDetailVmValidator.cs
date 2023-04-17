using BikeRental.ViewModels;
using FluentValidation;

namespace BikeRental.Validators
{
    public class VehicleDetailVmValidator : AbstractValidator<VehicleDetailViewModel>
    {
        public VehicleDetailVmValidator() 
        {
            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .MinimumLength(3).WithMessage("Nazwa marki musi zawierać min. 3 znaki");
            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Oznaczenie modelu jest wymagane");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .MinimumLength(20).WithMessage("Opis musi zawierać przynajmniej 20 znaków");
            RuleFor(x => x.RentCost)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .GreaterThanOrEqualTo(0.0).WithMessage("Cena wynajmu musi być wartością dodatnią");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .Must(IsValidUrl).WithMessage("Niepoprawny format URL");
            //TODO: category name
           
        }

        private bool IsValidUrl(string url)
        {
            Uri? uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
      
    }
}
