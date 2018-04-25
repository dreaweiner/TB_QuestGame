using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The Protection of the Socerer's Stone" };
        public static List<string> FooterText = new List<string>() { "Mrs. D's Productions, 2018" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "It's 1999 England. You are Harry Potter at your first year at Hogwarts. " +
            "You've just discovered that Professor Dumbledore is out of the castle. " +
            "Professor Snape will go after the Socerer's Stone without Dumbledore's presence. " +
            "Your mission is to protect the stone. Lord Voldemort must not return and gain immortality.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your mission begins now.\n" +
            " \n" +
            "\tYour first task will be to set up the initial parameters of your mission.\n" +
            " \n" +
            "\tPress any key to begin the Mission Initialization Process.\n";

            return messageBoxText;
        }

        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "You are now outside the door of Fluffy's chamber which leads to the Socercer's Stone. " +
            "Ron and Hermione are with you to help protect the stone. Hermione had to place a binding spell on " +
            "Neville because he unknowingly tried to stop y'all from completing your mission. " +
            "In order to get to the stone the three of you must fight the unknown dangers found beyond Fluffy. Good luck.\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin your mission we much gather your base data.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerName()
        {
            string messageBoxText =
                "Enter your name user name.\n" +
                " \n" +
                "Please use the name you wish to be referred during your mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerAge(Player gameplayer)
        {
            string messageBoxText =
                $"Very good then, we will call you {gameplayer.Name} on this mission.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n";

            return messageBoxText;
        }

        public static string InitializeMissionGetPlayerRace(Player gameplayer)
        {
            string messageBoxText =
                $"{gameplayer.Name}, it will be important for us to know your Wizarding World identifier on this mission.\n" +
                " \n" +
                "Enter your identifier below.\n" +
                " \n" +
                "Please use the universal idenifiers below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoPlayerInfo(Player gameplayer)
        {
            string messageBoxText =
                $"Very good then {gameplayer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tUser Name: {gameplayer.Name}\n" +
                $"\tUser Age: {gameplayer.Age}\n" +
                $"\tUser Identifier: {gameplayer.Race}\n" +
                " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion
        
        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player gameplayer)
        {
            string messageBoxText =
                $"\tUser Name: {gameplayer.Name}\n" +
                $"\tUser Age: {gameplayer.Age}\n" +
                $"\tUser Identifier: {gameplayer.Race}\n" +
                " \n";

            return messageBoxText;
        }

        public static string ListSpaceTimeLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Space-Time Locations\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                spaceTimeLocationList +=
                    $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                    $"{spaceTimeLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        ///<summary>
        /// look around
        /// </summary>
        public static string LookAround(SpaceTimeLocation spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.GeneralContents;

            return messageBoxText;
        }

        ///<summary>
        /// travel
        /// </summary>
        public static string Travel(Player gametraveler, List<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                $"{gametraveler.Name}, Aion Base will need to know the name of the new location.\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except the current location
            //
            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                if (spaceTimeLocation.SpaceTimeLocationID != gametraveler.SpaceTimeLocationID)
                {
                    spaceTimeLocationList +=
                        $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                        $"{spaceTimeLocation.CommonName}".PadRight(30) +
                        $"{spaceTimeLocation.Accessible}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        /// <summary>
        /// display current location information
        /// </summary>
        /// <param name="spaceTimeLocation"></param>
        /// <returns></returns>
        public static string CurrentLocationInfo(SpaceTimeLocation spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.Description;

            return messageBoxText;
        }

        /// <summary>
        /// show the visited locations
        /// </summary>
        /// <param name="spaceTimeLocations"></param>
        /// <returns></returns>
        public static string VisitedLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Space-Time Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                spaceTimeLocationList +=
                    $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                    $"{spaceTimeLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        public static List<string> StatusBox(Player player, Universe universe)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {player.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {player.Health}\n");
            statusBoxText.Add($"Lives: {player.Lives}\n");

            return statusBoxText;
        }

        ///<summary>
        /// list all of the game objects
        /// </summary>
        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Space-Time Location ID".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.SpaceTimeLocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        #endregion
    }
}
# endregion