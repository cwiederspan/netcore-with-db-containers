using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace SqlTest.Site.Models {

    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

            // Nothing to do here yet
        }

        public DbSet<Item> Items { get; set; }
    }
}
