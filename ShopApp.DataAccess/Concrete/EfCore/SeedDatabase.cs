﻿using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
	public static class SeedDatabase
	{
		public static void Seed()
		{
			var context = new ShopContext();

			if (context.Database.GetPendingMigrations().Count()==0)
			{
				if(context.Categories.Count()==0)
				{
					context.Categories.AddRange(Categories);
				}

				if (context.Products.Count() == 0)
				{
					context.Products.AddRange(Products);
				}

				context.SaveChanges();
			}
		}

		private static Category[] Categories =
		{
			new Category()
			{
				Name="Telefon"
			},
			new Category()
			{
				Name="Bilgisayar"
			}
		};

		private static Product[] Products =
		{
			new Product()
			{
				Name="Samsung S5",
				Price=2000,
				ImageUrl="1.jpg"
			},new Product()
			{
				Name="Samsung S6",
				Price=2100,
				ImageUrl="1.jpg"
			},new Product()
			{
				Name="Samsung S7",
				Price=2200,
				ImageUrl="1.jpg"
			},new Product()
			{
				Name="Samsung S8",
				Price=2300,
				ImageUrl="4.jpg"
			},new Product()
			{
				Name="Samsung S9",
				Price=2400,
				ImageUrl="3.jpg"
			},new Product()
			{
				Name="Samsung S10",
				Price=2500,
				ImageUrl="5.jpg"
			},new Product()
			{
				Name="Samsung S10",
				Price=2600,
				ImageUrl="1.jpg"
			}
		};
		
	}
}
