namespace IWantApp.src.Infra.Data;

using IWantApp.src.Domain.Products;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {
    
    public DbSet<Product>? Products {get; set;} 

    public DbSet<Category> Categories {get; set;}

    // ApplicationDbContext Variaveis de ambiente
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        
    }

    // Escreve e define propriedades dos campos de uma tabela no banco de dadoss
    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();

        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();
    }

    // Criar convenlçoes no banco de dados
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration){
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
   
}