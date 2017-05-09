namespace ZooRestaurant.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.AddressModels;
    using Newtonsoft.Json;
    using Web.Common.Constants;
    using Web.Common.Enums;
    using Web.Common.Helpers;

    public sealed class Configuration : DbMigrationsConfiguration<ZooRestaurantContext>
    {
        private ZooRestaurantContext context;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ZooRestaurantContext context)
        {
            this.context = context;

            this.SeedTownAndNeighborhoods("София", "Sofia");
            this.SeedTownAndNeighborhoods("Пловдив", "Plovdiv");

            this.CreateRoles();
            this.CreateAdminUser();

            this.CreateMealCategories();
            this.CreateMealsByCategory();

        }

    private void CreateMealsByCategory()
    {
        this.AddMealsFromJson("Resources/Salads/Salads.json", MealCategoryEnType.Salads);
        this.AddMealsFromJson("Resources/Starters/Starters.json", MealCategoryEnType.Starters);
        this.AddMealsFromJson("Resources/ChickenDishes/ChickenDishes.json", MealCategoryEnType.ChickenDishes);
        this.AddMealsFromJson("Resources/FishDishes/FishDishes.json", MealCategoryEnType.FishDishes);
        this.AddMealsFromJson("Resources/PorkDishes/PorkDishes.json", MealCategoryEnType.PorkDishes);
        this.AddMealsFromJson("Resources/BeafDishes/BeafDishes.json", MealCategoryEnType.BeafDishes);
        this.AddMealsFromJson("Resources/Garnitures/Garnitures.json", MealCategoryEnType.Garnitures);
        this.AddMealsFromJson("Resources/Desserts/Desserts.json", MealCategoryEnType.Desserts);
        this.AddMealsFromJson("Resources/Sauces/Sauces.json", MealCategoryEnType.Sauces);

    }

    private void AddMealsFromJson(string path, MealCategoryEnType category)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var filePath = PathHelper.MapPath(path, assembly);
        var mealsJson = File.ReadAllText(filePath);
        var meals = JsonConvert.DeserializeObject<IEnumerable<Meal>>(mealsJson).ToArray();

        var categoryName = category.GetDisplayName();
        var mealCategory = this.context.MealCategories.First(c => c.Name == categoryName);

        foreach (var meal in meals)
        {
            meal.CategoryId = mealCategory.Id;
            meal.Image.Content = File.ReadAllBytes(PathHelper.MapPath(meal.Image.UrlPath, assembly));
        }

        this.context.Meals.AddOrUpdate(m => m.Name, meals);
        this.context.SaveChanges();
    }

    private void SeedTownAndNeighborhoods(string townNameCyrilic, string townNameLatin)
    {
        var town = new Town { Name = townNameCyrilic };
        this.context.Towns.AddOrUpdate(t => t.Name, town);
        this.context.SaveChanges();

        var neighborhoodsFilePath =
            PathHelper.MapPath($"Resources/Neighborhoods/{townNameLatin}Neighborhoods.txt", Assembly.GetExecutingAssembly());

        var townNeighborhoods = File.ReadAllLines(neighborhoodsFilePath)
                                     .Select(t => t.Trim())
                                     .Select(neighborhoodName => new Neighborhood
                                     {
                                         Name = neighborhoodName,
                                         TownId = town.Id
                                     })
                                     .ToArray();

        this.context.Neighborhoods.AddOrUpdate(n => n.Name, townNeighborhoods);
        this.context.SaveChanges();
    }

    private void CreateRoles()
    {
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));

        this.context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = RolesType.Admin }
                                                  , new IdentityRole { Name = RolesType.Customer }
                                                  , new IdentityRole { Name = RolesType.Dispatcher });

        this.context.SaveChanges();
    }

    private void CreateAdminUser()
    {
        if (!this.context.Users.Any(u => u.Email == "ivo@abv.bg"))
        {
            var userManager = new UserManager<User>(new UserStore<User>(this.context));
            var user = new User()
            {
                FirstName = "Ivaylo",
                LastName = "Kodov",
                UserName = "Ifaka",
                PhoneNumber = "0897903353",
                Email = "ivo@abv.bg",
                Address = new Address()
                {
                    AdditionalAddress = "бл.136",
                    NeighborhoodId = this.context.Neighborhoods.First().Id
                },
                Customer = new Customer()
                {
                    Comment = string.Empty,
                    ShoppingCart = new ShoppingCart()
                }
            };
            userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, RolesType.Admin);
            userManager.AddToRole(user.Id, RolesType.Customer);

            this.context.SaveChanges();
        }
    }

    private void CreateMealCategories()
    {
        var meals = Enum
                        .GetValues(typeof(MealCategoryEnType))
                        .Cast<MealCategoryEnType>()
                        .Select(c => c.GetDisplayName())
                        .Select(mealName => new MealCategory { Name = mealName })
                        .ToArray();

        this.context.MealCategories.AddOrUpdate(m => m.Name, meals);

        this.context.SaveChanges();
    }
}
}
