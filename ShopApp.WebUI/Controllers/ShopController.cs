﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Businesss.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
		private IProductService _productService;

		public ShopController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Details(int? id)
        {
			if (id==null)
			{
				return NotFound();
			}
			Product product = _productService.GetProductDetails((int)id);
			if (product==null)
			{
				return NotFound();
			}
			return View(new ProductDetailsModel()
			{
				Product = product,
				Categories = product.ProductCategories.Select(i => i.Category).ToList()
			});
        }

		public IActionResult List()
		{
			return View(new ProductListModel()
			{
				Products = _productService.GetAll()
			});

		}
	}
}