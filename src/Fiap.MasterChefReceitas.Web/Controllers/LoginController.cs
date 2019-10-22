using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Fiap.MasterChefReceitas.Core;
using Fiap.MasterChefReceitas.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fiap.MasterChefReceitas.Web.Controllers
{
    public class LoginController : Controller
    {


        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly IMemoryCache _memoryCache;

        public LoginController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._memoryCache = memoryCache;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await this.userManager.FindByNameAsync(model.User);

            if (user == null && model.User == "Master")
            {
                user = new ApplicationUser() { UserName = model.User };
                await this.userManager.CreateAsync(user, model.Password);
                user = await this.userManager.FindByNameAsync(model.User);
            }
            if (user != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(
                    model.User, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var url = new Uri($"http://localhost:5001/api/Account/{model.User}/{model.Password}");
                    var response = await new HttpClient().GetStringAsync(url);
                    var json = (JObject)JsonConvert.DeserializeObject(response);
                    string cacheEntry;
                    if (!_memoryCache.TryGetValue(model.User, out cacheEntry))
                    {
                        cacheEntry = json["accessToken"].Value<string>();

                        var cacheEntryOptions = new MemoryCacheEntryOptions();

                        _memoryCache.Set(model.User, cacheEntry, cacheEntryOptions);
                    }

                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError(string.Empty, "Falha ao Login");
            return View("Index", model);
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.User
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            _memoryCache.Remove(signInManager.Context.User.Identity.Name);
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View("Index");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await this.userManager.FindByNameAsync(model.User);

            var result = await this.userManager.ChangePasswordAsync(user, model.PasswordOld, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Falha ao alterar senha");
            return View(model);
        }

    }
}