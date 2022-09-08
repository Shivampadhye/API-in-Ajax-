using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskWebAPI.Models;

namespace TaskWebAPI.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }
        public DbSet<TaskWebAPI.Models.Student> Student { get; set; }
    }
}
