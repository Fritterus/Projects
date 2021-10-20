using CarSharing.Entities;
using CarSharing.Models;
using CarSharing.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarSharing.Controllers
{
    public class RentController : Controller
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Order> _orderRepository;

        public RentController(IRepository<Order> orderRepository, IRepository<Car> carRepository)
        {
            _orderRepository = orderRepository;
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult Rent(int carId, decimal cost)
        {
            var viewModel = new RentCarViewModel
            {
                CarId = carId,
                Cost = cost,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(RentCarViewModel viewModel)
        {
            var order = new Order

            {
                EndDate = viewModel.EndDate,
                StartDate = viewModel.StartDate,
                CarId = viewModel.CarId,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                TotalCost = (viewModel.EndDate - viewModel.StartDate).Days * viewModel.Cost,
            };

            await _orderRepository.CreateAsync(order);

            var car = await _carRepository.GetAsync(viewModel.CarId);
            car.Status = 2;

            await _carRepository.UpdateAsync(car);


            return RedirectToAction("Index", "Home");
        }

        public IActionResult CalculateCost(RentCarViewModel viewModel)
        {
            viewModel.TotalCost = (viewModel.EndDate - viewModel.StartDate).Days * viewModel.Cost;

            return View("Rent", viewModel);
        }
    }
}
