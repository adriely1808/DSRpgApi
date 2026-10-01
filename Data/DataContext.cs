using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        //ctor--> cria um construtor (atalho)
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }


        public DbSet<Arma> TB_ARMAS { get; set;}
 
        public DbSet<Personagem> TB_PERSONAGENS { get; set; }



        /// override--> sobre escrito 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");

            modelBuilder.Entity<Personagem>().HasData
            (
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
            );

            
            modelBuilder.Entity<Arma>().HasData(

            new Arma {id=1, Nome="Arco e Flecha", Dano= 35},
            new Arma {id=2, Nome="Espada Longa", Dano= 50 },
            new Arma {id=3, Nome="Adaga", Dano= 60},
            new Arma {id=4,Nome="Machado de Batalha", Dano= 55},
            new Arma {id=5,Nome="Cajado Encantado", Dano=70},
            new Arma {id=6,Nome="Lança", Dano= 45},
            new Arma {id=7,Nome="Martelo de Guerra", Dano=65}
            );
   




         //metodo on model creating


        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
           configurationBuilder.Properties<string>()
            .HaveColumnType("varchar").HaveMaxLength(200);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning));
        }



















    }
}