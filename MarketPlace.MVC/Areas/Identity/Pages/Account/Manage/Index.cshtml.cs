// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketPlace.MVC.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Username")]
            public string Username { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [StringLength(8, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }


            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Shippings Address")]
            public string ShipAddress { get; set; }


            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Shippings City")]
            public string ShipCity { get; set; }


            [StringLength(8, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            [Display(Name = "Shippings Zip Code")]
            public string ShipZipCode { get; set; }


            [Phone]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 7)]
            [Display(Name = "Shippings Phone number")]
            public string ShipPhoneNumber { get; set; }


            [EmailAddress]
            [Display(Name = "Shippings Email")]
            public string ShipEmail { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            string userName = await _userManager.GetUserNameAsync(user);
            string phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string address = user.Address;
            string city = user.City;
            string zipcode = user.ZipCode;
            string shipAddress = user.ShipAddress;
            string shipCity = user.ShipCity;
            string shipZipCode = user.ShipZipCode;
            string shipPhoneNumber = user.ShipPhoneNumber;
            string shipEmail = user.ShipEmail;
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName =firstName,
                LastName = lastName,
                Address = address,
                City = city,
                ZipCode = zipcode,
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipZipCode = shipZipCode,
                ShipPhoneNumber = shipPhoneNumber,
                ShipEmail = shipEmail

            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            string phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                IdentityResult setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string address = user.Address;
            string city = user.City;
            string zipcode = user.ZipCode;
            string shipAddress = user.ShipAddress;
            string shipCity = user.ShipCity;
            string shipZipCode = user.ShipZipCode;
            string shipPhoneNumber = user.ShipPhoneNumber;
            string shipEmail = user.ShipEmail;
            if (Input.FirstName != firstName)
            {

                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Address != address)
            {
                user.Address = Input.Address;
                await _userManager.UpdateAsync(user);
            }

            if (Input.City != city)
            {
                user.City = Input.City;
                await _userManager.UpdateAsync(user);
            }

            if (Input.ZipCode != zipcode)
            {
                user.ZipCode = Input.ZipCode;
                await _userManager.UpdateAsync(user);
            }

            if (Input.ShipAddress != shipAddress)
            {
                user.ShipAddress = Input.ShipAddress;
                await _userManager.UpdateAsync(user);
            }

            if (Input.ShipCity != shipCity)
            {
                user.ShipCity = Input.ShipCity;
                await _userManager.UpdateAsync(user);
            }
            if (Input.ShipZipCode != shipZipCode)
            {
                user.ShipZipCode = Input.ShipZipCode;
                await _userManager.UpdateAsync(user);
            }

            if (Input.ShipPhoneNumber != shipPhoneNumber)
            {
                user.ShipPhoneNumber = Input.ShipPhoneNumber;
                await _userManager.UpdateAsync(user);
            }

            if (Input.ShipEmail != shipEmail)
            {
                user.ShipEmail = Input.ShipEmail;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Username != user.UserName)
            {
                User userNameExists = await _userManager.FindByNameAsync(Input.Username);
                if (userNameExists != null)
                {
                    StatusMessage = "User name already taken. Select a different username.";
                    return RedirectToPage();
                }

                IdentityResult setUserName = await _userManager.SetUserNameAsync(user, Input.Username);
                if (!setUserName.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set user name.";
                    return RedirectToPage();
                }
                else
                {
                   await _userManager.UpdateAsync(user);
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

       
    }
}
