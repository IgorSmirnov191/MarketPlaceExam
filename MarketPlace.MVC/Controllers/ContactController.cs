using Marketplace.Services.Interfaces;
using MarketPlace.MVC.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Controllers
{

    public class ContactController : Controller
    {
        private readonly IMessageService messageService;
        

        public ContactController(IMessageService messageService)
        {
            this.messageService = messageService;
           
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }
   
            var result = await this.messageService.Create(inputModel.Name, inputModel.Email, inputModel.Phone, inputModel.Message);
           

            return this.Redirect("/");
        }
    }
}
