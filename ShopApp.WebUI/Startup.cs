﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Business.Concrete;
using ShopApp.Businesss.Abstract;
using ShopApp.Businesss.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.DataAccess.Concrete.Memory;
using ShopApp.WebUI.Middlewares;

namespace ShopApp.WebUI
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IProductDal, EfCoreCategoryDal>();
			services.AddScoped<ICategoryDal, EfCategoryDal>();
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<ICategoryService, CategoryManager>();

			services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				SeedDatabase.Seed();
			}
			app.UseStaticFiles();
			app.CustomStaticFiles();
			app.UseMvcWithDefaultRoute();
			
		}
	}
}
