using Restaurant_Reservation.Datenbank;
using Restaurant_Reservation.Klassen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Reservation.Service
{
    public class RestaurantInitializer
    {
        public async Task<List<Restaurant>> InitializeRestaurantsAsync()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "La Petite France",
                    Description = "French cuisine in a cozy atmosphere.",
                    Location = new Location { Street = "1470 rue Peel", HouseNumber = "1", City = "Montreal", PostalCode = "H3A 1T1", Country = "Canada" },
                    Valuation = 4,
                    Cuisine = "French",
                    OpeningTime = TimeSpan.FromHours(18),
                    ClosingTime = TimeSpan.FromHours(22),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "The Spotted Pig",
                    Description = "Gastropub with seasonal dishes.",
                    Location = new Location { Street = "314 West 11th Street", HouseNumber = "", City = "New York", PostalCode = "10014", Country = "USA" },
                    Valuation = 5,
                    Cuisine = "Gastropub",
                    OpeningTime = TimeSpan.FromHours(17),
                    ClosingTime = TimeSpan.FromHours(23),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Dinner by Heston Blumenthal",
                    Description = "Innovative British dishes by a renowned chef.",
                    Location = new Location { Street = "66 Knightsbridge", HouseNumber = "", City = "London", PostalCode = "SW1X 7LA", Country = "UK" },
                    Valuation = 5,
                    Cuisine = "British",
                    OpeningTime = TimeSpan.FromHours(18),
                    ClosingTime = TimeSpan.FromHours(23),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 4,
                    Name = "El Celler de Can Roca",
                    Description = "Award-winning restaurant serving creative Catalan cuisine.",
                    Location = new Location { Street = "Carrer de Can Sunyer", HouseNumber = "48", City = "Girona", PostalCode = "17007", Country = "Spain" },
                    Valuation = 5,
                    Cuisine = "Spanish",
                    OpeningTime = TimeSpan.FromHours(13),
                    ClosingTime = TimeSpan.FromHours(15),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 5,
                    Name = "Sukiyabashi Jiro",
                    Description = "Renowned sushi restaurant with a fixed menu.",
                    Location = new Location { Street = "2 Chome-15-2 Roppongi", HouseNumber = "", City = "Minato City", PostalCode = "106-0032", Country = "Japan" },
                    Valuation = 5,
                    Cuisine = "Japanese",
                    OpeningTime = TimeSpan.FromHours(12),
                    ClosingTime = TimeSpan.FromHours(15),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 6,
                    Name = "Osteria Francescana",
                    Description = "Michelin-starred Italian restaurant.",
                    Location = new Location { Street = "Via Stella", HouseNumber = "22", City = "Modena", PostalCode = "41121", Country = "Italy" },
                    Valuation = 5,
                    Cuisine = "Italian",
                    OpeningTime = TimeSpan.FromHours(12),
                    ClosingTime = TimeSpan.FromHours(14),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 7,
                    Name = "Narisawa",
                    Description = "Innovative Japanese cuisine with a focus on sustainability.",
                    Location = new Location { Street = "Minami Aoyama", HouseNumber = "2 Chome-6-15", City = "Minato City", PostalCode = "107-0062", Country = "Japan" },
                    Valuation = 5,
                    Cuisine = "Japanese",
                    OpeningTime = TimeSpan.FromHours(12),
                    ClosingTime = TimeSpan.FromHours(14),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 8,
                    Name = "Mirazur",
                    Description = "Seaside restaurant with panoramic views and innovative cuisine.",
                    Location = new Location { Street = "30 Avenue Aristide Briand", HouseNumber = "", City = "Menton", PostalCode = "06500", Country = "France" },
                    Valuation = 5,
                    Cuisine = "French",
                    OpeningTime = TimeSpan.FromHours(12),
                    ClosingTime = TimeSpan.FromHours(14),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                },
                new Restaurant
                {
                    Id = 9,
                    Name = "Geranium",
                    Description = "Modern Nordic cuisine in an elegant setting.",
                    Location = new Location { Street = "Per Henrik Lings Allé", HouseNumber = "4", City = "Copenhagen", PostalCode = "2100", Country = "Denmark" },
                    Valuation = 5,
                    Cuisine = "Nordic",
                    OpeningTime = TimeSpan.FromHours(12),
                    ClosingTime = TimeSpan.FromHours(14),
                    TableCapacities = new Dictionary<int, int> { {4, 1}, {2, 1}, {6, 1} }
                }
            };

            // Upload each restaurant to the database
            foreach (var restaurant in restaurants)
            {
                await DatabaseHelper.PostRestaurant(restaurant);
            }

            return restaurants;
        }
    }
}
