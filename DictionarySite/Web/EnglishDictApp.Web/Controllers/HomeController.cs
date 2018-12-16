namespace EnglishDictApp.Web.Controllers
{
    using EnglishDictApp.Data;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        private ApplicationDbContext context;
        private IRepository<ApplicationUser> userRepo;
        private IRepository<ApplicationRole> roleRepo;

        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context, IRepository<ApplicationUser> userRepo, IRepository<ApplicationRole> roleRepo)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
            this.userRepo = userRepo;
            this.roleRepo = roleRepo;
        }

        public IActionResult Index()
        {
            var p = userRepo.All();

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
