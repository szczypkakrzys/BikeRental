using AutoMapper;
using BikeRental.DAL;
using BikeRental.Models;
using BikeRental.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace BikeRental.Controllers
{
    [Authorize(Roles = "User, Operator, Administrator")]
    public class ReservationController : Controller
    {
        private IRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;
        private IValidator<ReservationViewModel> _validator;
        public ReservationController(IMapper mapper, IValidator<ReservationViewModel> validator)
        {
            _reservationRepository = new RepositoryService<Reservation>(new DatabaseContext());
            _mapper = mapper;
            _validator = validator;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel reservation)
        {
            ValidationResult result = _validator.Validate(reservation);
            if (!result.IsValid)
            {
                //server-side validation testing
                //var modelStateDictionary = new ModelStateDictionary();
                //foreach (ValidationFailure failure in result.Errors)
                //{
                //    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                //}

                //return ValidationProblem(modelStateDictionary);

                //client-side :)
                return View(reservation);
            }

            Reservation reservationModel = _mapper.Map<Reservation>(reservation);
            _reservationRepository.Add(reservationModel);
            return RedirectToAction("Index");
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
