using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDeveloperAssessment.Models;

namespace WebDeveloperAssessment.Data
{
    public class WebDeveloperAssessmentContext : DbContext
    {
        public WebDeveloperAssessmentContext (DbContextOptions<WebDeveloperAssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<WebDeveloperAssessment.Models.Student> Student { get; set; } = default!;
    }
}
