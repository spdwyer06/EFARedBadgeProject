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

            context.Games.AddOrUpdate(
                game => new { game.GameTitle, game.PlatformType },
                // PS4 Games
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Call of Duty: Ghosts", Price = 10 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.T, GameTitle = "Crash Bandicoot: N Sane Trilogy", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "Dark Souls", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Destiny", Price = 10 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "Deus Ex: Mankind Divided", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Doom", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Doom Eternal", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.Platformer, RatingType = Game.TypeOfRating.T, GameTitle = "Mighty No. 9", Price = 10 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Titanfall 2", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.Playstation4, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "The Witcher 3: Wild Hunt", Price = 25 },
                // Xbox One Games
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.T, GameTitle = "Anthem", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Battlefield Hardline", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Battlefield V", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "Borderlands 2", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "Borderlands 3", Price = 50 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.Sports, RatingType = Game.TypeOfRating.E, GameTitle = "Dangerous Driving", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.Sports, RatingType = Game.TypeOfRating.E, GameTitle = "Forza Horizon 2", Price = 15 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.Sports, RatingType = Game.TypeOfRating.E, GameTitle = "Forza Horizon 3", Price = 25 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Halo 5: Guardians", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.XboxOne, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Halo: The Master Chief Collection", Price = 30 },
                // Nintendo Switch Games
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.E, GameTitle = "Animal Crossing: New Horizons", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.M, GameTitle = "Bayonetta", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.T, GameTitle = "Fortnite", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.E, GameTitle = "Luigi's Mansion 3", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Sports, RatingType = Game.TypeOfRating.E, GameTitle = "Mario Kart 8", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.E, GameTitle = "Pokemon: Sword", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Sports, RatingType = Game.TypeOfRating.E, GameTitle = "Rocket League", Price = 25 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.E, GameTitle = "Spyro: Reignited Trilogy", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.E, GameTitle = "Super Mario Party", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.NintendoSwitch, CategoryType = Game.TypeOfCategory.Fighting, RatingType = Game.TypeOfRating.E, GameTitle = "Super Smash Bros. Ultimate", Price = 40 },
                // PC Games
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.T, GameTitle = "ARK: Survival", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "Cyberpunk 2077", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Deadside", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Destiny 2", Price = 20 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.RPG, RatingType = Game.TypeOfRating.M, GameTitle = "Fallout 76", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.T, GameTitle = "No Man's Sky", Price = 40 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Red Dead Redemption 2", Price = 30 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.FPS, RatingType = Game.TypeOfRating.M, GameTitle = "Resident Evil 3", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.M, GameTitle = "Sekiro: Shadows Die Twice", Price = 60 },
                new Game { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000000"), PlatformType = Game.TypeOfPlatform.PC, CategoryType = Game.TypeOfCategory.Adventure, RatingType = Game.TypeOfRating.E, GameTitle = "Terraria", Price = 40 }
                );
        }
    }
}
