using System.Linq;
using ShowBiz.Models;
using Spectre.Console;

namespace ShowBiz
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ShowBizContext();

            var movies = db.Movies.OrderByDescending(movie => movie.Name);
            var totalMinutes = movies.Count();//movies.Sum(movie => movie.Duration.TotalMinutes));
            Output.Results(movies, "Movies",
                new Table()
                    .MinimalBorder()
                    .BorderColor(Color.Yellow)
                    .AddColumn(nameof(Movie.Name))
                    .AddColumn(nameof(Movie.Duration), column => column.Footer($"[purple]{totalMinutes}[/]"))
                    .AddRows(movies, 
                        movie => $"[red]{movie.Name}[/]",
                        movie => $"[green]{movie.Duration.ToString()}[/]"
                        )
            );
            
        }
    }
}