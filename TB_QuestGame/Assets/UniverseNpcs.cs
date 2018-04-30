using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        /// <summary>
        /// list the NPCs
        /// </summary>
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 1,
                Name = "Man with Stripped Hat",
                SpaceTimeLocationID = 2,
                Description = "A tall man in baggy pants with a red, pin stripped hat.",
                Messages = new List<string>
                {
                    "Greetings stranger. You are not from these parts as I can see.",
                    "You will find what you are looking for with the Pink Gorilla.",
                    "I once attended the Academy. They felt I needed more candles."
                },
                ExperiencePoints = 45,
                IsDeadly = true,
                Value = -1
            },

            new Civilian
            {
                Id = 2,
                Name = "Timothy Sargent",
                SpaceTimeLocationID = 1,
                Description = "The lead developer of the Stratus Flux Capacitor.",
                Messages = new List<string>
                {
                    "I have to go. Good bye!",
                    "It was always meant for good. We had no idea.",
                    "Is that man following you?"
                }
            },

            new Civilian
            {
                Id = 3,
                Name = "Thorian Diplomat",
                SpaceTimeLocationID = 2,
                Description = "A Thorian diplomat dressed in traditional phlox and cords."
            },

            new Civilian
            {
                Id = 4,
                Name = "Murphy",
                SpaceTimeLocationID = 1,
                Description = "An orange tabby cat.",
                Messages = new List<string>
                {
                    "Meow."
                },
                ExperiencePoints = 45,
                IsDeadly = true,
                Value = -1
            },

            new Civilian
            {
                Id = 5,
                Name = "Snarf",
                SpaceTimeLocationID = 1,
                Description = "A magical witch with a purple bonnet.",
                Messages = new List<string>
                {
                    "You will gain so much from life."
                },
                ExperiencePoints = 40
            }
        };
        // fix all of these NPCs
    }
}
