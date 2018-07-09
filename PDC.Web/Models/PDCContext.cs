using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    public class PDCContext : DbContext
    {
        public PDCContext(DbContextOptions<PDCContext> options) : base(options) { }
        public DbSet<tAnswer> tAnswer { get; set; }
        public DbSet<tAnswerHistory> tAnswerHistory { get; set; }
        public DbSet<tApplicant> tApplicant { get; set; }
        public DbSet<tApplicantProgram> tApplicantProgram { get; set; }
        public DbSet<tAppllicantAnswer> tApplicantAnswer { get; set; }
        public DbSet<tCity> tCity { get; set; }
        public DbSet<tClient> tClient { get; set; }
        public DbSet<tGroup> tGroup { get; set; }
        public DbSet<tGroupMenu> tGroupMenu { get; set; }
        public DbSet<tMenu> tMenu { get; set; }
        public DbSet<tProgram> tProgram { get; set; }
        public DbSet<tProgramQuestion> tProgramQuestion { get; set; }
        public DbSet<tProvince> tProvince { get; set; }
        public DbSet<tQuestion> tQuestion { get; set; }
        public DbSet<tUser> tUser { get; set; }
        public DbSet<tApplicantHistory> tApplicantHistory { get; set; }
        public DbSet<tApplicantTutorial> tApplicantTutorial { get; set; }
        public DbSet<tType> tType { get; set; }
        public DbSet<tDomain> tDomain { get; set; }
        public DbSet<tBatch> tBatch { get; set; }
    }
}
