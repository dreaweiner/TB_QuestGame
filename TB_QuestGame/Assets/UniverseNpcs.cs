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
                Name = "Peeves",
                SpaceTimeLocationID = 1,
                Description = "Peeves, the poltergeist.",
                Messages = new List<string>
                {
                    "Shan't say nothing if you don't say please.",
                },
                IsDeadly = true,
                Value = -1
            },

            new Civilian
            {
                Id = 2,
                Name = "Filch",
                SpaceTimeLocationID = 1,
                Description = "The lead developer of the Stratus Flux Capacitor.",
                Messages = new List<string>
                {
                    "“Which way did they go, Peeves?",
                    "Quick, tell me."
                },
                Value = 1
            },

            new Civilian
            {
                Id = 3,
                Name = "Professor Qwirrell",
                SpaceTimeLocationID = 6,
                Description = "Harry’s first Defence Against the Dark Arts teacher is a clever young wizard who took a ‘Grand Tour’ around the world before taking up his teaching post at Hogwarts. When Harry first meets Quirrell, he has adopted a turban for everyday wear.",
                Messages = new List<string>
                {
                    "Me, I wondered whether I’d be meeting you here, Potter.",
                    "Yes, Severus does seem the type, doesn’t he? So useful to have him swooping around like an overgrown bat. Next to him, who would suspect p-p-poor ststuttering P-Professor Quirrell?",
                    
                },
                Value = 150
            },

            new Civilian
            {
                Id = 4,
                Name = "Murphy",
                SpaceTimeLocationID = 4,
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
                SpaceTimeLocationID = 4,
                Description = "A magical witch with a purple bonnet.",
                Messages = new List<string>
                {
                    "You will gain so much from life."
                },
                ExperiencePoints = 40
            },

            new Civilian
            {
                Id = 6,
                Name = "Voldemort",
                SpaceTimeLocationID = 6,
                Description = "He is a very powerful Dark Wizard and the Dark Lord of the Death Eaters; who aims to take over the wizarding world and shape it following his supremacist views.",
                Messages = new List<string>
                {
                    "There is no good and evil. There is only power, and those too weak to seek it.",
                    "Get the stone"
                },
                ExperiencePoints = 250
                
            }
        };
    }
}
