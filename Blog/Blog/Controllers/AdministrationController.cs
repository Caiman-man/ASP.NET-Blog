using Blog.Areas.Identity.Data;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDBContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: Administration
        public ActionResult Index()
        {
            var viewModel = new AdministrationFormViewModel
            {
                Roles = _roleManager.Roles.ToList(),        // получить список ролей
                Users = _context.Users.ToList()             // получить список пользователей
            };

            return View(viewModel);
        }

        //GET: /Administration/New - вызов формы для заполнения данных пользователя
        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }

        //регистрация нового пользователя
        [HttpPost]
        public async Task<ActionResult> NewUser(NewUserFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Administration/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new NotFoundResult();
                }

                // Удаление пользователя
                var user = await _userManager.FindByIdAsync(id);
                var logins = await _userManager.GetLoginsAsync(user);
                var rolesForUser = await _userManager.GetRolesAsync(user);

                // Открытие транзакции для комплексного удаления
                using (var transaction = _context.Database.BeginTransaction())
                {
                    // Удалить логин пользователя
                    foreach (var login in logins.ToList())
                    {
                        await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
                    }

                    // Удалить пользователя из ролей
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            var result = await _userManager.RemoveFromRoleAsync(user, item);
                        }
                    }

                    // Удаление пользователя
                    await _userManager.DeleteAsync(user);

                    // Фиксация транзакции удаления
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //------------------------------------------------------------------------------------
        //GET: /Administration/NewRole - вызов формы для заполнения новой роли
        [HttpGet, ActionName("NewRole")]
        public IActionResult CreateNewRole()
        {
            return View();
        }

        [HttpPost, ActionName("NewRole")]
        public async Task<ActionResult> CreateNewRole(NewRoleFormViewModel model)
        {
            await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
            return RedirectToAction("Index");
        }

        // GET: /Administration/DeleteRole/1
        [HttpGet, ActionName("DeleteRole")]
        public async Task<ActionResult> DeleteRoleConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new NotFoundResult();
                }

                // Удаление роли
                var role = await _roleManager.FindByIdAsync(id);
                await _roleManager.DeleteAsync(role);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        //------------------------------------------------------------------------------------
        //Изменение ролей пользователя
        public async Task<IActionResult> EditRole(string userId)
        {
            //получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                //получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(string userId, List<string> roles)
        {
            //получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
