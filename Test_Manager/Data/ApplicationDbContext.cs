using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test_Manager.Models;

namespace Test_Manager.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Administrateur> administrateurs { get; set; }
    public DbSet<Gestionnaire> gestionnaires { get; set; }
    public DbSet<Entreprise> entreprises { get; set; }
    public DbSet<Candidat> candidats { get; set; }
    public DbSet<Campagne> campagnes { get; set; }
    public DbSet<Test> tests { get; set; }
    public DbSet<QuestionCode> questionCodes { get; set; }
    public DbSet<QuestionQCM> questionQCMs { get; set; }
    public DbSet<QuestionRedaction> questionRedactions { get; set; }
    public DbSet<ReponseCode> reponseCodes { get; set; }
    public DbSet<ReponseQCM> reponseQCMs { get; set; }
    public DbSet<ReponseRedaction> reponseRedactions { get; set; }
    public DbSet<ResultatTest> resultatTests { get; set; }
    public DbSet<ResultatCampagne> resultatCampagnes { get; set; }
    public DbSet<AdministrateurRole> administrateurRoles { get; set; }
    public DbSet<GestionnaireRole> gestionnaireRoles { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<User>("User")
            .HasValue<Administrateur>("Administrateur")
            .HasValue<Gestionnaire>("Gestionnaire");
    }
}
