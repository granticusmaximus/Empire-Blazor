using Empire.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Empire.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Severity)
                .HasConversion<string>();
            modelBuilder.Entity<TicketTechNote>()
                .HasKey(ttn => new { ttn.TicketId, ttn.TechNoteId });

            modelBuilder.Entity<TicketTechNote>()
                .HasOne(ttn => ttn.Ticket)
                .WithMany(t => t.TicketTechNotes)
                .HasForeignKey(ttn => ttn.TicketId);

            modelBuilder.Entity<TicketTechNote>()
                .HasOne(ttn => ttn.TechNote)
                .WithMany(tn => tn.TicketTechNotes)
                .HasForeignKey(ttn => ttn.TechNoteId);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TechNote> Notes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketTechNote> TicketTechNotes { get; set; }
    }
}