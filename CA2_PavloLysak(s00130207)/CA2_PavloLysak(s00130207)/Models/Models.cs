using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2_PavloLysak_s00130207_.Models
{
    class MovieSeed: DropCreateDatabaseAlways<MovieDb>
	{
        protected override void Seed(MovieDb context)
        {
            var directors = new List<Director>()
            {
                new Director() {DirectorName= "DNAME1", DirectorSurname = "DSURNAME1"},
                new Director() {DirectorName= "DNAME2", DirectorSurname = "DSURNAME2"}
            };
            directors.ForEach(drcks => context.DirectorsContext.Add(drcks));


            var movies = new List<Movie>()
            {
                new Movie() {MovieName = "Movie1", MovieReleaseDate = DateTime.Parse("1,1,2000"),
                Director = context.DirectorsContext.SingleOrDefault(d=>d.DirectorName == "DNAME1"),
                Actors = new List<Actor>()
                {
                    new Actor()
                    {
                        ActorName = "Actor1",
                        Sex = Sex.Female
                    },
                    new Actor()
                    {
                        ActorName = "Actor1",
                        Sex = Sex.Female
                    },
                    new Actor()
                    {
                        ActorName = "Actor1",
                        Sex = Sex.Male
                    }
                }},
               
            
                new Movie() {MovieName = "Movie2", MovieReleaseDate = DateTime.Parse("1,1,2010"),
                Director = context.DirectorsContext.SingleOrDefault(d=>d.DirectorName == "DNAME2"),
                Actors = new List<Actor>()
                {
                    new Actor()
                    {
                        ActorName = "Actor4",
                        Sex = Sex.Female
                    },
                    new Actor()
                    {
                        ActorName = "Actor5",
                        Sex = Sex.Female
                    }
                    
                }},
                new Movie() {MovieName = "Movie3", MovieReleaseDate = DateTime.Parse("1,1,2014"),
                    Director = context.DirectorsContext.FirstOrDefault(d=>d.DirectorName=="DNAME2")}
            };

            movies.ForEach(mvs => context.MoviesContext.Add(mvs));
            context.SaveChanges();
            base.Seed(context);






            //////////////
            //Movie a = new Movie()
            //{
            //    MovieName = "Test1", MovieReleaseDate= DateTime.Parse("1/1/2000")
            //};
            //context.MoviesContext.Add(a);

            //Actor Jack = new Actor() { ActorName = "Actor Name", Sex =Sex.Male };
            //a.Actors = new List<Actor>();
            //a.Actors.Add(Jack); 
            ////////////////


           
            
        }     
	}

    class MovieDb : DbContext
    {
        public DbSet<Movie> MoviesContext { get; set; }
        public DbSet<Actor> ActorsContext { get; set; }
        public DbSet<Director> DirectorsContext { get; set; }

        public MovieDb()
            :base("MovieConnString"){}
    }

    public class Movie
    {
        [Key]

        public int MovieId { get; set; }
        [Display(Name="Movie Name:")]
        public string MovieName { get; set; }
        [DisplayName("Release Date:"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MovieReleaseDate { get; set; }

        public virtual Director Director { get; set; }
        public List<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public Sex Sex { get; set; }

        public Movie Movie { get; set; }
    }

    public enum Sex
    {
        Male, Female
    }

    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }

        private string FullName
        {
            get { return String.Format("{0}. {1}", DirectorName[0], DirectorSurname); }
        }
    }

}