using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
        //{
        //    Projects = new List<Project>
        //   {
        //        new Project("Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
        //        new Project("Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 10000),
        //        new Project("Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 10000)
        //   };

        //    Users = new List<User>
        //    {
        //        new User("Alan Martins", "alanmartins@gmail.com", new DateTime(2001,10,30)),
        //        new User("Adrielison Ferreira", "adrielisonferreira@gmail.com", new DateTime(1997,08,10)),
        //        new User("Jorge Alves", "jorgealves@gmail.com", new DateTime(1989,02,06))
        //    };

        //    Skills = new List<Skill>
        //    {
        //        new Skill(".NET Core"),
        //        new Skill("C#"),
        //        new Skill("Javascript"),
        //    };
        //}

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
