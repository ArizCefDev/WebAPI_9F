﻿using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options):
			base(options)
		{ 
		}
		
	}
}
