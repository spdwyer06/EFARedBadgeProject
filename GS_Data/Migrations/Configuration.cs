namespace GS_Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Games.AddOrUpdate(
            //    game => new { game.GameTitle, game.PlatformType },
            //    new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Doom", Price = 20 },
            //    new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Doom Eternal", Price = 60 }
            //    );
        }
    }
}
