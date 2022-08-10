using AutoMapper;
using Marketplace.App.Areas.Administrator.ViewModels.Users;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Areas.Administrator.Controllers
{
    public class UsersController : AdministratorController
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public UsersController(IMapper mapper, IUserService usersService, UserManager<User> userManager)
        {
            this.mapper = mapper;
            userService = usersService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult All()
        {
            Task<IEnumerable<MarketPlaceExam.Business.Model.UserModel>> users = userService.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            MarketPlaceExam.Business.Model.UserModel user = await userService.GetUser(id);
            if(user == null)
            {
                return RedirectToAction(nameof(All));
            }

            DeleteUserViewModel userModel = mapper.Map<DeleteUserViewModel>(user);
            
            return View(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> Destroy(string id)
        {
            await userService.DeleteUser(id);

            return  RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Roles(string id)
        {
            List<string> userRoles = userService.GetUserRoles(id)
                .GetAwaiter()
                .GetResult()
                .ToList();

            RolesViewModel userRolesModel = new RolesViewModel()
            {
                Id = id,
                Roles = userRoles
            };

            return View(userRolesModel);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            MarketPlaceExam.Business.Model.UserModel user = await userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            AdminChangePasswordInputModel modelResult = mapper.Map<AdminChangePasswordInputModel>(user);

            return View(modelResult);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangePassword(string id, AdminChangePasswordInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            IdentityResult result = await userService.ChangePassword(id, inputModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(All));
            }
            else
            {
                foreach (IdentityError? error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(inputModel);
            }
        }
    }
}