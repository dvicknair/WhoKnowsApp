using Microsoft.EntityFrameworkCore;
using WhoKnowsGame.Shared.Models;

namespace WhoKnowsGame.Data;

public class WhoKnowsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Riddle> Riddles { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerRiddleAnswer> PlayerRiddleAnswers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSeeding((context, _) =>
    //    {
    //        var testBlog = context.Set<Riddle>().FirstOrDefault();
    //        if (testBlog == null)
    //        {
    //            context.Set<Riddle>().Add(new Riddle { Question = "Favorite Color?" });
    //            context.SaveChanges();
    //        }
    //    });
    //    base.OnConfiguring(optionsBuilder);
    //}
}
