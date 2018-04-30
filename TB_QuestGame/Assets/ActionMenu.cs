using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        /// <summary>
        /// current menu enum
        /// </summary>
        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            ObjectMenu,
            NpcMenu,
            PlayerMenu,
            AdminMenu
        }
        
        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        /// <summary>
        /// mission introduction
        /// </summary>
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        /// <summary>
        /// initialize the mission
        /// </summary>
        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '0', PlayerAction.Exit }
                }
        };

        /// <summary>
        /// main menu
        /// </summary>
        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.LookAround },
                    { '2', PlayerAction.Travel },
                    { '3', PlayerAction.ObjectMenu },
                    { '4', PlayerAction.NonplayerCharacterMenu },
                    { '5', PlayerAction.PlayerMenu },
                    { '6', PlayerAction.AdminMenu },
                    { '0', PlayerAction.Exit }
                }
        };

        /// <summary>
        /// administration menu
        /// </summary>
        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.ListLocations },
                    { '2', PlayerAction.ListGameObjects},
                    { '3', PlayerAction.ListNonplayerCharacters },
                    { '0', PlayerAction.ReturnToMainMenu }
                }
        };

        /// <summary>
        /// player menu
        /// </summary>
        public static Menu PlayerMenu = new Menu()
        {
            MenuName = "PlayerMenu",
            MenuTitle = "Player Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    { '2', PlayerAction.Inventory},
                    { '3', PlayerAction.LocationsVisited},
                    { '0', PlayerAction.ReturnToMainMenu }
                }
        };

        /// <summary>
        /// object menu
        /// </summary>
        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.LookAt },
                    { '2', PlayerAction.PickUp},
                    { '3', PlayerAction.PutDown},
                    { '0', PlayerAction.ReturnToMainMenu }
                }
        };

        /// <summary>
        /// non-playable character
        /// </summary>
        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.TalkTo},
                    { '0', PlayerAction.ReturnToMainMenu }
                }

        };
    }
}
