﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Demo.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Switch Pattern
            //WriteLine(ToPositionalText(1));

            // Tuple Pattern
            //WriteLine(ToPointName((0,0)));

            // Property, Recusrive, & Var Patterns
            //PrintDrinks();

            // Deconstruct Pattern
            PrintFood();
        }

        static string ToPositionalText(int i)
        {
            return i switch
            {
                1 => "First",
                2 => "Second",
                3 => "Third",
                _ => $"{i}th"
            };
        }

        static string ToPointName((int x, int y) point)
        {
            switch (point)
            {
                case (0,0):
                    return "Center";

                default:
                    return "Unknown";
            }

            // Also Works:
            //return point switch 
            //{
            //    (0,0) => "Center",
            //    _     => "Unknown"
            //};
        }

        static void PrintDrinks()
        {
            var menuItems = new[]
            {
                new MenuItem { Name = "Pizza", Category = "Food", Price = new Price { Currency = "USD", Amount = 14.00 } },
                new MenuItem { Name = "Sprite", Category = "Drink", Price = new Price { Currency = "USD", Amount = 7.00 } },
                new MenuItem { Name = "Fanta", Category = "Drink", Price = new Price { Currency = "EUR", Amount = 2.00 } }
            };

            foreach (var item in menuItems)
            {
                if (item is { Category: "Drink", Name: var name, Price: { Currency: "USD", Amount: var price } })
                    WriteLine($"{name} ${price}");
            }
        }

        static void PrintFood()
        {
            // These Are Tuples
            var menuItems = new[]
            {
                (Name: "Pizza", Category: "Food", Price: 14.00, Description: "12 Inch Pie"),
                (Name: "Sprite", Category: "Drink", Price: 7.00, Description: "Super Expensive Soda"),
                (Name: "Fanta", Category: "Drink", Price: 2.00, Description: "Moderately Prices Soda")
            };

            foreach(var item in menuItems)
            {
                if (item is (var name, _, var price, _))
                    WriteLine($"{name} ${price}");
            }
        }
    }

    class MenuItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Price Price { get; set; }
    }

    class Price
    {
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
}
