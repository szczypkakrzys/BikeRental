using BikeRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //simple db just for now ;)
        private List<Vehicle> VehiclesList = new List<Vehicle>()
        {
            new Vehicle {Id=1, isElectric=false, Description="Korzystając z doświadczenia kolarzy powstał KROSS Level 11.0. Prawdziwa maszyna, której przeznaczeniem jest agresywna jazda w terenie czy walka na kresce.", rentCost= 200},
            new Vehicle {Id=2 , isElectric=true, Description="Rower elektryczny to nasza propozycja dla osób poszukających nowych wyzwań i oczekujących od roweru czegoś „ekstra”. Zbudowany zgodnie ze wszystkimi standardami wymaganymi obecnie od rowerów górskich typu trail i w oparciu o wydajny oraz aktywnie wspomagający rowerzystę silnik Shimano STEPS. Dzięki temu na szczyt dotrzesz szybciej i mniej zmęczony, pozostawiając sobie więcej czasu na niczym nieskrępowaną jazdę w dół.", rentCost=300},
            new Vehicle {Id=3, isElectric=true, Description="Podstawowy model roweru hardtail wyposażonego we wspomaganie elektryczne. Ten e-bike to doskonały wybór dla każdego chcącego sprawdzić swoich sił w nowej dyscyplinie lub poszukującego roweru do objechania trasy wyścigu w komfortowych warunkach bez nadmiernego zmęczenia organizmu przed ważnym startem.", rentCost=250}
        };

        public IActionResult ShowAllVehicles()
        {
            return View(VehiclesList);
        }

        public IActionResult VehicleDetails(int id)
        {
            var info = VehiclesList.Find(x => x.Id == id);
            return View(info);
        }
    }
}
