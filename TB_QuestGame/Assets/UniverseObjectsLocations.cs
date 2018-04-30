using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UniverseObjects
    {
        public static List<SpaceTimeLocation> SpaceTimeLocations = new List<SpaceTimeLocation>()
        {
            ///<summary>
            /// list locations
            /// </summary>
            new SpaceTimeLocation
            {
                CommonName = "Fluffy's Chamber",
                SpaceTimeLocationID = 1,
                UniversalDate = 5/9/1999,
                UniversalLocation = "1",
                Description = "Fluffy's Chamber is a large room with little but the three headed dog" +
                    "known as Fluffy and a trap door on the floor and a harp playing music.\n",
                GeneralContents = "The room is a large and well lit room. There is a harp and Fluffy. ",
                Accessible = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Devil's Snare",
                SpaceTimeLocationID = 2,
                UniversalDate = 5/9/1999,
                UniversalLocation = "2",
                Description = "The Devil's Snare room is a dark room full of plant like material. ",
                GeneralContents = "The room is full of Devil's Snare.",
                Accessible = false,
                ExperiencePoints = 20
            },

            new SpaceTimeLocation
            {
                CommonName = "The Key Room",
                SpaceTimeLocationID = 3,
                UniversalDate = 5/9/1999,
                UniversalLocation = "3",
                Description = "The room is a large chamber with valted ceilings. There is a single " +
                              "broomstick and hundreds of bird like keys floating about the room. ",
                GeneralContents = "There are thousands of keys and a broomstick. The door across the chamber is locked.",
                Accessible = false,
                ExperiencePoints = 30
            },

            new SpaceTimeLocation
            {
                CommonName = "Wizard's Chess",
                SpaceTimeLocationID = 4,
                UniversalDate = 5/9/1999,
                UniversalLocation = "4",
                Description = "The room is dark until you walk further into the chamber. In the center of the room" +
                              "is a giant chessboard. Around the edges of the board is a graveyard of conquered pieces. " +
                              "As you walk across the chessboard, the opposing chess team's pawns stop you from proceeding forward.",
                GeneralContents = "The lives sized chessboard.",
                Accessible = false,
                ExperiencePoints = 50
            },

            new SpaceTimeLocation
            {
                CommonName = "Potions Challenge",
                SpaceTimeLocationID = 5,
                UniversalDate = 5/9/1999,
                UniversalLocation = "5",
                Description = "The Danger lies before you, while safety lies behind," +
                              "Two of us will help you, whichever you would find," +
                              "One among us seven will let you move ahead," +
                              "Another will transport the drinker back instead," +
                              "Two among our number hold only nettle wine," +
                              "Three of us are killers, waiting hidden in line." +
                              "Choose, unless you wish to stay here for evermore," +
                              "To help you in your choice, we give you these clues four:" +
                              "First, however slyly the poison tries to hide" +
                              "You will always find some on nettle wine’s left side;" +
                              "Second, different are those who stand at either end," +
                              "But if you would move onwards, neither is your friend;" +
                              "Third, as you see clearly, all are different size," +
                              "Neither dwarf nor giant holds death in their insides;" +
                              "Fourth, the second left and the second on the right" +
                              "Are twins once you taste them, though different at first sight.",
                GeneralContents = "The poem and seven differently shaped bottles.",
                Accessible = false,
                ExperiencePoints = 60
            },

            new SpaceTimeLocation
            {
                CommonName = "The Mirror Room",
                SpaceTimeLocationID = 6,
                UniversalDate = 5/9/1999,
                UniversalLocation = "6",
                Description = "The room has the Mirror of Erised and an additional character. ",
                GeneralContents = "The Mirror of Erised is in the room.",
                Accessible = false,
                ExperiencePoints = 100
            },
        };
    }
}
