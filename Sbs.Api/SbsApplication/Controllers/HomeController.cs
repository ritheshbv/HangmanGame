using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SbsApplication.Models;
using SbsApplication.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SbsApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService loginService;
        private readonly IRegistrationService registrationService;

        public HomeController(ILogger<HomeController> logger, ILoginService loginService, IRegistrationService registrationService)
        {
            this.loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            this.registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService)); ;

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(this.loginService.Model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<RedirectToActionResult> Create(UserViewModel userViewModel)
        {
            var result = await this.registrationService.RegisterUser(userViewModel);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Register");
        }

        public async Task<RedirectToActionResult> LogIn(LoginViewModel loginViewModel)
        {
            var result = await this.loginService.AuthenticateUser(loginViewModel);

            if (result)
            {
                return RedirectToAction("Level", "Hangman");
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
