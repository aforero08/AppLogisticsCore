using AppLogistics.DataContext.Models;
using AppLogistics.WebApp.Models.AccountViewModels;
using AppLogistics.WebApp.Models.ApplicationUserViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLogistics.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, ILogger logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = new List<ApplicationUserDetailsViewModel>();

            foreach (var user in _userManager.Users.OrderBy(u => u.Name))
            {
                var viewUser = _mapper.Map<ApplicationUserDetailsViewModel>(user);
                viewUser.CurrentRol = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                users.Add(viewUser);
            }

            return View(users);
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            var currentRole = await _userManager.GetRolesAsync(appUser);
            var viewUser = _mapper.Map<ApplicationUserDetailsViewModel>(appUser);
            viewUser.CurrentRol = currentRole.FirstOrDefault();

            return View(viewUser);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            var viewUser = GetEditViewModelUser(appUser);

            return View(viewUser);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, ApplicationUserEditViewModel viewModelUser)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || !viewModelUser.Id.Equals(id))
                {
                    return BadRequest();
                }

                var appUser = await _userManager.FindByIdAsync(id);
                if (appUser == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    if (!await UpdateUserAsync(appUser, viewModelUser))
                    {
                        return View(GetEditViewModelUser(appUser));
                    }

                    return RedirectToAction(nameof(Index));
                }

                viewModelUser = GetEditViewModelUser(appUser);
                return View(viewModelUser);
            }
            catch
            {
                return View();
            }
        }

        private ApplicationUserEditViewModel GetEditViewModelUser(ApplicationUser appUser)
        {
            var viewUser = _mapper.Map<ApplicationUserEditViewModel>(appUser);
            viewUser.SelectedRol = _userManager.GetRolesAsync(appUser).Result.FirstOrDefault();
            viewUser.Roles = _roleManager.Roles.ToList().Select(r => new SelectListItem
            {
                Value = r.NormalizedName,
                Text = r.Name,
                Selected = r.Name == viewUser.SelectedRol
            });
            return viewUser;
        }

        private async Task<bool> UpdateUserAsync(ApplicationUser appUser, ApplicationUserEditViewModel editedUser)
        {
            if (!editedUser.Name.Equals(appUser.Name, StringComparison.OrdinalIgnoreCase))
            {
                appUser.Name = editedUser.Name;
            }

            if (!editedUser.PhoneNumber.Equals(appUser.PhoneNumber, StringComparison.OrdinalIgnoreCase))
            {
                appUser.PhoneNumber = editedUser.PhoneNumber;
            }

            if (!editedUser.Email.Equals(appUser.Email, StringComparison.OrdinalIgnoreCase))
            {
                var existingUser = await _userManager.FindByEmailAsync(editedUser.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Ya existe un usuario registrado con ese email.");
                    return false;
                }
                appUser.Email = editedUser.Email;
            }

            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(appUser);
                if (!currentRoles.Contains(editedUser.SelectedRol))
                {
                    result = await _userManager.RemoveFromRolesAsync(appUser, currentRoles);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(appUser, editedUser.SelectedRol);
                        if (result.Succeeded)
                        {
                            return true;
                        }
                        AddIdentityErrors(result);
                    }
                    AddIdentityErrors(result);
                }
            }
            AddIdentityErrors(result);
            return false;
        }

        private void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.Log(LogLevel.Error, error.Description);
            }
        }
    }
}