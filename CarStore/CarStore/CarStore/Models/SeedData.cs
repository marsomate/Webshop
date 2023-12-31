﻿using CarStore.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarStore.Models
{
    // This class provides seed data to ensure the initial presence of cars in the database.
    public static class SeedData
    {
        // Method to ensure the population of the database with initial data.
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // Create a scoped CarStoreDbContext instance using dependency injection.
            CarStoreDbContext context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<CarStoreDbContext>();

            // Apply any pending migrations to the database.
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Check if the 'Cars' table is empty.
            if (!context.Cars.Any())
            {
                // If the table is empty, add a set of predefined cars.
                context.Cars.AddRange(
                    // Car entries with various makes, models, conditions, descriptions, and prices.
                    new Car
                    {
                        Make = "Suzuki",
                        Model = "Swift",
                        Condition = "A little rusty",
                        Description = "A little rusty small Suzuki Swift mk2 from 1993. Made in Hungary with Japanese parts. Can roll around in the city.",
                        Price = 200_0m
                    },
                        new Car
                        {
                            Make = "Ford",
                            Model = "Focus",
                            Condition = "Perfect",
                            Description = "It has a very big engine. It sounds like vroooooooooooom without pressing gas.",
                            Price = 300_0m
                        },
                        new Car
                        {
                            Make = "Audi",
                            Model = "TT",
                            Condition = "Perfect",
                            Description = "The best car if you want to go fast and show off to your friends. (and also pay a lot for gas and police tickets and repair)",
                            Price = 1_200_0m
                        },
                        new Car
                        {
                            Make = "Skoda",
                            Model = "Fabia",
                            Condition = "Good",
                            Description = "Good for cruising in the city, not able to overtake at all, due to its small engine",
                            Price = 800_0m
                        },
                        new Car
                        {
                            Make = "Toyota",
                            Model = "Corolla",
                            Condition = "Well-maintained",
                            Description = "Reliable Toyota Corolla from 2005. Well-maintained with a spacious interior. Perfect for daily commuting.",
                            Price = 350_0m
                        },
                        new Car
                        {
                            Make = "Ford",
                            Model = "Mustang",
                            Condition = "Excellent",
                            Description = "Powerful Ford Mustang from 2018. Excellent condition with a sleek design. Ideal for those who love speed and style.",
                            Price = 600_0m
                        },
                        new Car
                        {
                            Make = "Honda",
                            Model = "Civic",
                            Condition = "Good",
                            Description = "Fuel-efficient Honda Civic from 2010. Good condition and reliable. Suitable for daily commuting.",
                            Price = 250_0m
                        },
                        new Car
                        {
                            Make = "Chevrolet",
                            Model = "Malibu",
                            Condition = "Like new",
                            Description = "Sleek Chevrolet Malibu from 2015. Like new with modern features. Perfect for a comfortable ride.",
                            Price = 450_0m
                        },
                        new Car
                        {
                            Make = "Nissan",
                            Model = "Altima",
                            Condition = "Low mileage",
                            Description = "Efficient Nissan Altima from 2019. Low mileage and well-maintained. Great for long drives.",
                            Price = 550_0m
                        },
                        new Car
                        {
                            Make = "Volkswagen",
                            Model = "Golf",
                            Condition = "Well-maintained",
                            Description = "Classic Volkswagen Golf from 2013. Well-maintained and fuel-efficient. Ideal for urban driving.",
                            Price = 300_0m
                        },
                        new Car
                        {
                            Make = "Mercedes-Benz",
                            Model = "C-Class",
                            Condition = "Luxurious",
                            Description = "Luxurious Mercedes-Benz C-Class from 2017. Powerful engine and stylish interior. A statement of elegance.",
                            Price = 700_0m
                        },
                        new Car
                        {
                            Make = "Subaru",
                            Model = "Outback",
                            Condition = "Versatile",
                            Description = "Versatile Subaru Outback from 2016. Spacious and capable for both city and off-road adventures.",
                            Price = 400_0m
                        },
                        new Car
                        {
                            Make = "Audi",
                            Model = "A4",
                            Condition = "Excellent",
                            Description = "Sleek Audi A4 from 2014. Excellent condition with advanced technology features. A perfect blend of performance and style.",
                            Price = 500_0m
                        },
                        new Car
                        {
                            Make = "Hyundai",
                            Model = "Elantra",
                            Condition = "Reliable",
                            Description = "Reliable Hyundai Elantra from 2012. Fuel-efficient and comfortable for everyday use. Well-suited for city life.",
                            Price = 280_0m
                        },
                        new Car
                        {
                            Make = "Jeep",
                            Model = "Wrangler",
                            Condition = "Off-road ready",
                            Description = "Off-road ready Jeep Wrangler from 2018. Powerful and rugged, perfect for adventure seekers and outdoor enthusiasts.",
                            Price = 600_0m
                        });
                

                // Save changes to the database.
                context.SaveChanges();
            }
        }
    }
}
