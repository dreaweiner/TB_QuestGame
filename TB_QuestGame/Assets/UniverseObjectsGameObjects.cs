﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public partial class UniverseObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new PlayerObject
            {
                Id = 1,
                Name = "Harp",
                SpaceTimeLocationId = 1,
                Description = "A musical instrument playing gentle soothing music.",
                IsVisible = true
            },

            new PlayerObject
            {
                Id = 2,
                Name = "Hagrid's Flute",
                SpaceTimeLocationId = 1,
                Description = "A woodwind instrument that plays sweet music.",
                CanInventory = true,
                IsVisible = true,
                Value = 45
            },

            new PlayerObject
            {
                Id = 3,
                Name = "Wand",
                SpaceTimeLocationId = 2,
                Description = "A wand is a thin, hand-held stick or rod made of wood, stone, ivory, and magical cores.",
                CanInventory = true,
                Value = 100,
                IsVisible = true
            },

            new PlayerObject
            {
                Id = 4,
                Name = "Invisibility Cloak",
                SpaceTimeLocationId = 1,
                Description = "An invisibility cloak is a magical garment which renders whomever or whatever it covers unseeable. These are common items that are massed produced in the wizarding world. The first known cloak was made by Death for Ignotus Peverell in the 13th century and it is one of a kind.",
                IsVisible = true,
                IsConsumable = false,
                CanInventory = true,
                Value = 200
            },

            new PlayerObject
            {
                Id = 5,
                Name = "Damaged Winged Key",
                SpaceTimeLocationId = 3,
                Description = "It is a big old-fashioned silver key. It has bright blue wings. This flying key is hobbling through space, trying to fly within the cohort of fellow keys.",
                IsVisible = true,
                CanInventory = true,
                Value = 50,
                IsConsumable = true
            },

            new PlayerObject
            {
                Id = 6,
                Name = "Skeleton Key",
                SpaceTimeLocationId = 3,
                Description = "This key is flying through space. It is metal with a skull on the handle.",
                IsVisible = true,
                CanInventory = false,
                Value = -50,
                IsDeadly = true
            },

            new PlayerObject
            {
                Id = 7,
                Name = "Wooden Key",
                SpaceTimeLocationId = 3,
                Description = "This flying key is zooming around like a kingfisher. It is bright blue.",
                IsVisible = true,
                CanInventory = false,
                Value = -50,
                IsDeadly = true
            },

            new PlayerObject
            {
                Id = 8,
                Name = "Broomstick",
                SpaceTimeLocationId = 3,
                Description = "Broomsticks, also known as brooms, are one of the means employed by wizards and witches to transport themselves between locations. Their use in Great Britain and Ireland is regulated by the Ministry of Magic's Broom Regulatory Control.",
                IsVisible = true,
                CanInventory = true,
                Value = 50,
                IsConsumable = true
            },

            //put in something regarding the chess chamber

            new PlayerObject
            {
                Id = 9,
                Name = "Potion Bottle No. 1",
                SpaceTimeLocationId = 5,
                //poison
                IsVisible = true,
                CanInventory = false,
                Value = -25,
                IsConsumable = true,
                IsDeadly = true
            },

            new PlayerObject
            {
                Id = 10,
                Name = "Potion Bottle No. 2",
                SpaceTimeLocationId = 5,
                //poison
                IsVisible = true,
                CanInventory = false,
                Value = -25,
                IsConsumable = true,
                IsDeadly = true
            },

            new PlayerObject
            {
                Id = 11,
                Name = "Potion Bottle No. 3",
                SpaceTimeLocationId = 5,
                //poison
                IsVisible = true,
                CanInventory = false,
                Value = -25,
                IsConsumable = true,
                IsDeadly = true
            },

            new PlayerObject
            {
                Id = 12,
                Name = "Potion Bottle No. 4",
                SpaceTimeLocationId = 5,
                //wine
                IsVisible = true,
                CanInventory = false,
                Value = -15,
                IsConsumable = true,
                IsDeadly = false
            },

            new PlayerObject
            {
                Id = 13,
                Name = "Potion Bottle No. 5",
                SpaceTimeLocationId = 5,
                //wine
                IsVisible = true,
                CanInventory = false,
                Value = -15,
                IsConsumable = true,
                IsDeadly = false
            },

            new PlayerObject
            {
                Id = 14,
                Name = "Potion Bottle No. 6",
                SpaceTimeLocationId = 5,
                Description = "This is a small bottle that will get you through the black fire towards the Sorcerer's Stone.",
                //gets you safely back through the black fire
                IsVisible = true,
                CanInventory = true,
                Value = 25,
                IsConsumable = true,
                IsDeadly = false
            },

            new PlayerObject
            {
                Id = 15,
                Name = "Potion Bottle No. 7",
                SpaceTimeLocationId = 5,
                Description = "This is a round bottle that will get you back throught the purple fire which leads you back to the castle.",
                //gets you back through the purple
                IsVisible = true,
                CanInventory = true,
                Value = 25,
                IsConsumable = true,
                IsDeadly = false
            }

            //add an information piece for the final room
        };
    }
}
