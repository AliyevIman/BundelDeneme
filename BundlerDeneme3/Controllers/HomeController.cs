using BundlerDeneme3.Data_Acces;
using BundlerDeneme3.Entites;
using BundlerDeneme3.Entites.DTO;
using BundlerDeneme3.Models;
using BundlerDeneme3.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BundlerDeneme3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryDb _context;
        public HomeController(ILogger<HomeController> logger, CategoryDb context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var categoryList = _context.categories.Include(c=>c.CategoryWithChild).ToList();

            IndexVM vm = new()
            {
                Categories = categoryList.Where(c => c.CategoryWithChild.Any(par => par.ParentCategoryId == c.Id))
                .Select(cat => new CategoryWithChilderen()
                {
                    CatgoryId = cat.Id,
                    CatgoryName = cat.Name,
                    Childeren = categoryList
                    .Where(cat => cat.CategoryWithChild.Any(child => cat.Id==child.ParentCategoryId)).Select(c=>new Category
                    {
                        Id=c.Id,
                        Name=c.Name,
                        PhotoUrl=c.PhotoUrl,
                        Title=c.Title,
                    }).ToList()
                }).ToList()
            };
            return View(vm);
        }
        //public void ExtractSubCategories(CategoryWithChild category)
        //{
        //    var obshi = _context.categories.ToList();
        //        obshi.Where(c => c.Id == categ).Select(cat => new CategoryWithChilderen()
        //        {
        //            CatgoryId = cat.CategoryId,
        //            CatgoryName = cat.Category.Name,
        //            Childeren = obshi.Where(c => c.ParentCategoryId == cat.id && c.ParentCategoryId != null).ToList(),
        //        }).ToList()
            
        //    return View(indexVm);

           
          
        //} 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]  
        public IActionResult Error()  
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}