using AutoMapper;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Areas.Administrator.Controllers
{
    public class OrdersController : AdministratorController
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Orders()
        {
            Task<IEnumerable<MarketPlaceExam.Business.Model.OrderModel>> result = orderService.GetAllOrders();
                  

            return View(result);
        }

        [HttpGet]
        public IActionResult ViewOrder(string id)
        {
            //to do:

            return RedirectToAction(nameof(Orders));
        }
    }
}
