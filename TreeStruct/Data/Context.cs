using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStruct.Models;
using TreeStruct.ViewModels;

namespace TreeStruct.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Category> Categories{ get; set; }

        public DbSet<TreeStruct.ViewModels.TreeViewModel> TreeViewModel { get; set; }
    }
}
