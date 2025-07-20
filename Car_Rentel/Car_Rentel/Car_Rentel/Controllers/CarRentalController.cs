using Car_Rentel.Data;
using Car_Rentel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rentel.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show cars catalog page
        [HttpGet]
        public IActionResult Cars()
        {
            return View();
        }

        // Show rental form, accept optional selected carName
        [HttpGet]
        public IActionResult CarRent(string carName)
        {
            var model = new CarRental();

            if (!string.IsNullOrEmpty(carName))
            {
                ViewBag.SelectedCar = carName;
                model.CarModel = carName; // pre-fill the car model in the form
            }

            return View(model);
        }

        // Handle form POST submission
        [HttpPost]
        public IActionResult CarRent(CarRental rental)
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }

            _context.CarRentals.Add(rental);
            _context.SaveChanges();

            // Redirect to payment page after successful submission
            return RedirectToAction("Payment", new { id = rental.Id });
        }

        // Payment page (simplified)
        [HttpGet]
        public IActionResult Payment(int id)
        {
            var rental = _context.CarRentals.Find(id);
            if (rental == null)
                return NotFound();

            return View(rental);
        }
        public IActionResult ProcessPayment(int rentalId, string cardNumber, string expiry, string cvv)
        {
            // TODO: Add your payment validation and processing logic here.
            // For example, call your payment gateway API.

            var rental = _context.CarRentals.Find(rentalId);
            if (rental == null)
            {
                return NotFound();
            }

            // Here you can optionally update rental/payment status in the database
            // e.g. rental.IsPaid = true;
            // _context.SaveChanges();

            ViewBag.Message = $"Payment for {rental.CarModel} rental was successful!";

            return View("PaymentSuccessful");
        }
    }
}