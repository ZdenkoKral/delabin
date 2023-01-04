using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DelabinService.Models;

namespace DelabinService.Data
{
    public class DelabinServiceContext : DbContext
    {
        public DelabinServiceContext (DbContextOptions<DelabinServiceContext> options)
            : base(options)
        {
        }

        public DbSet<DelabinService.Models.Document> Document { get; set; } = default!;
        public DbSet<DelabinService.Models.DocData> Data { get; set; } = default!;
    }
}
