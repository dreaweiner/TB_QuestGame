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
        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            AdminMenu
        }

        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    { '2', PlayerAction.LookAround },
                    { '3', PlayerAction.LookAt },
                    { '4', PlayerAction.Travel },
                    { '5', PlayerAction.PlayerLocationsVisited },
                    { '6', PlayerAction.ListSpaceTimeLocations },
                    { '7', PlayerAction.ListGameObjects },
                    { '0', PlayerAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.ListSpaceTimeLocations },
                    { '2', PlayerAction.ListGameObjects},
                    { '0', PlayerAction.ReturnToMainMenu }
                }
        };


        //public static Menu Manageplayer = new Menu()
        //{
        //    MenuName = "Manageplayer",
        //    MenuTitle = "Manage player",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.MissionSetup,
        //                PlayerAction.playerInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
