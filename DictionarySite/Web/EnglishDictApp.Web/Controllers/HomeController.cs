namespace EnglishDictApp.Web.Controllers
{
    using EnglishDictApp.Data;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : BaseController
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        private ApplicationDbContext context;
        private IRepository<ApplicationUser> userRepo;
        private IRepository<ApplicationRole> roleRepo;
        private SignInManager<ApplicationUser> signInManager;
        public HomeController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext context,
            IRepository<ApplicationUser> userRepo,
            IRepository<ApplicationRole> roleRepo,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
            this.userRepo = userRepo;
            this.roleRepo = roleRepo;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.View("LoggedInHomeView");
            }
            else
            {
                return this.View("AnonymousHomeView");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
