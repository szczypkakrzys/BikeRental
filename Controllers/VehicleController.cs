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

        
        private List<Vehicle> VehiclesList = new List<Vehicle>()
        {
            new Vehicle {Id=1, isElectric=false, Description="Korzystając z doświadczenia kolarzy powstał KROSS Level 11.0. Prawdziwa maszyna, której przeznaczeniem jest agresywna jazda w terenie czy walka na kresce.", RentCost= 200, Image="https://kross.eu/media/cache/gallery/rc/zljyawzs/images/38/38297/KRLV1129X19M002406-KR-LEVEL-11.0-NIE-BIA-P-1.jpg"},
            new Vehicle {Id=2 , isElectric=true, Description="Rower elektryczny to nasza propozycja dla osób poszukających nowych wyzwań i oczekujących od roweru czegoś „ekstra”. Zbudowany zgodnie ze wszystkimi standardami wymaganymi obecnie od rowerów górskich typu trail i w oparciu o wydajny oraz aktywnie wspomagający rowerzystę silnik Shimano STEPS. Dzięki temu na szczyt dotrzesz szybciej i mniej zmęczony, pozostawiając sobie więcej czasu na niczym nieskrępowaną jazdę w dół.", RentCost=300, Image="https://kross.eu/media/cache/gallery/rc/6hltpx2v/images/43/43250/KRSB2ZMUX20M003089-KR-Soil-Boost-2.0-630-XL-zielony-czarny-matowy2.png"},
            new Vehicle {Id=3, isElectric=true, Description="Podstawowy model roweru hardtail wyposażonego we wspomaganie elektryczne. Ten e-bike to doskonały wybór dla każdego chcącego sprawdzić swoich sił w nowej dyscyplinie lub poszukującego roweru do objechania trasy wyścigu w komfortowych warunkach bez nadmiernego zmęczenia organizmu przed ważnym startem.", RentCost=250, Image="https://kross.eu/media/cache/gallery/rc/9jbbdd9a/images/50/50098/KRVB1Z29X20M005659-KR-Level-BOOST-1.0-CZA_GRA-LIM-P-1.jpg"}
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
