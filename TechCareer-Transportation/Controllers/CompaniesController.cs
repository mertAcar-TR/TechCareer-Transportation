using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class CompaniesController : Controller
    {
        private ICompanyRepository _companyRepository;
        private ICommentRepository _commentRepository;
        private IDemandRepository _demandRepository;

        public CompaniesController(ICompanyRepository companyRepository, ICommentRepository commentRepository, IDemandRepository demandRepository)
        {
            _companyRepository = companyRepository;
            _commentRepository = commentRepository;
            _demandRepository = demandRepository;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var companies = _companyRepository.Companies;

            return View(new CompanyViewModel { Companies = await companies.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
 
            var company = await _companyRepository
                        .Companies
                        .Include(x => x.Vehicles)
                        .ThenInclude(x => x.Workers)
                        .ThenInclude(x => x.Job)
                        .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                        .FirstOrDefaultAsync(p => p.Url == url);
            TempData["CompanyId"] = company.CompanyId;
            return View(company);
        }

        [HttpPost]
        public JsonResult AddComment(int CompanyId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                CompanyId = CompanyId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);

            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });

        }

        [Authorize]
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(DemandCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _demandRepository.CreateDemand(
                    new Demand
                    {
                        Text = model.Text,
                        CompanyId = model.CompanyId,
                        UserId=int.Parse(userId ?? ""),
                        DemandTime=DateTime.Now
                    }
                );
                TempData["AlertMessage"] = "Talebiniz alındı";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}


