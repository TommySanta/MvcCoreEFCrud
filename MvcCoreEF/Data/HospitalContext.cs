﻿using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options):base(options) 
        {
        }
        public DbSet<Hospital> Hospitales { get; set; }
    }
}