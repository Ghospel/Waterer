using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterer.API.Models;
using Waterer.Data.Entities;

namespace Waterer.Data.Context
{
    public class CropDbContext : DbContext
    {
        public DbSet<CropEntity> Crops { get; set; }
        public DbSet<CropStatusEntity> CropStatuses { get; set; }

        public CropDbContext(DbContextOptions<CropDbContext> options) : base(options) { }
    }
}
