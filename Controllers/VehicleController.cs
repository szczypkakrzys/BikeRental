using BikeRental.DAL;
using BikeRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Controllers
{
    public class VehicleController : Controller
    {
        private IRepository<Vehicle> _vehicleRepository;
        public VehicleController()
        {
            _vehicleRepository = new RepositoryService<Vehicle>(new DatabaseContext());
            //temporary solution to add vehicles
            foreach(var item in VehiclesList)
            {
                _vehicleRepository.Add(item);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAllVehicles()
        {
            var model = _vehicleRepository.GetAllRecords();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
           _vehicleRepository.Add(vehicle);
            return View();
        }

        public IActionResult VehicleDetails(Guid id)
        {
            var info = _vehicleRepository.GetSingle(id);
            return View(info);
        }


        private List<Vehicle> VehiclesList = new List<Vehicle>()
        {
            new Vehicle {isElectric=false, Description="Korzystając z doświadczenia kolarzy powstał KROSS Level 11.0. Prawdziwa maszyna, której przeznaczeniem jest agresywna jazda w terenie czy walka na kresce.", RentCost= 200, Image="https://kross.eu/media/cache/gallery/rc/zljyawzs/images/38/38297/KRLV1129X19M002406-KR-LEVEL-11.0-NIE-BIA-P-1.jpg", BrandName="KROSS", Model=" Level 11.0"},
            new Vehicle {isElectric=true, Description="Rower elektryczny to nasza propozycja dla osób poszukających nowych wyzwań i oczekujących od roweru czegoś „ekstra”. Zbudowany zgodnie ze wszystkimi standardami wymaganymi obecnie od rowerów górskich typu trail i w oparciu o wydajny oraz aktywnie wspomagający rowerzystę silnik Shimano STEPS. Dzięki temu na szczyt dotrzesz szybciej i mniej zmęczony, pozostawiając sobie więcej czasu na niczym nieskrępowaną jazdę w dół.", RentCost=300, Image="https://kross.eu/media/cache/gallery/rc/6hltpx2v/images/43/43250/KRSB2ZMUX20M003089-KR-Soil-Boost-2.0-630-XL-zielony-czarny-matowy2.png", BrandName="KROSS", Model=" Level 11.1"},
            new Vehicle {isElectric=true, Description="Podstawowy model roweru hardtail wyposażonego we wspomaganie elektryczne. Ten e-bike to doskonały wybór dla każdego chcącego sprawdzić swoich sił w nowej dyscyplinie lub poszukującego roweru do objechania trasy wyścigu w komfortowych warunkach bez nadmiernego zmęczenia organizmu przed ważnym startem.", RentCost=250, Image="https://kross.eu/media/cache/gallery/rc/9jbbdd9a/images/50/50098/KRVB1Z29X20M005659-KR-Level-BOOST-1.0-CZA_GRA-LIM-P-1.jpg",BrandName="KROSS", Model=" Level 11.2"}
        };


    }
}
