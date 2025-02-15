﻿using Microsoft.AspNetCore.Mvc;
using ProniaBusiness.Services.Abstracts;

namespace Prronia.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ShopController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var datas = _categoryService.GetAllCategories();
            return View(datas);
        }
        public IActionResult SingleProductVariable()
        {
            return View();
        }
    }
}
