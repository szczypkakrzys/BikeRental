using BikeRental.ViewModels;
using FluentValidation;

namespace BikeRental.Validators
{
    public class VehicleDetailVmValidator : AbstractValidator<VehicleDetailViewModel>
    {
        public VehicleDetailVmValidator() 
        {
            RuleFor(x => x.BrandName).NotEmpty().MinimumLength(3).WithMessage("Nazwa marki musi wynosić min. 3 znaki");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Oznaczenie modelu jest wymagane");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Opis musi wynosić przynajmniej 20 znaków");
            RuleFor(x => x.RentCost).GreaterThan(0).WithMessage("Cena wynajmju musi być wartością dodatnią");
            RuleFor(x => x.Image).Must(IsValidUrl).WithMessage("Niepoprawny format URL");
            //TODO: category name
            //temporarily:
            //RuleFor(x => x.categoryName).NotNull().WithMessage("Musisz podać nazwę kategorii");
        }

        private bool IsValidUrl(string url)
        {
            Uri? uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

    }
}
