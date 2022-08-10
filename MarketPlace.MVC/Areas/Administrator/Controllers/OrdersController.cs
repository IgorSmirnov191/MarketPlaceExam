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
            var result = this.orderService.GetAllOrders();
                  

            return this.View(result);
        }

        [HttpGet]
        public IActionResult ViewOrder(string id)
        {
            //to do:

            return this.RedirectToAction(nameof(Orders));
        }
    }
}
