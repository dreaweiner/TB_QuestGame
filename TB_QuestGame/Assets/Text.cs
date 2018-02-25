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

        public static string InitializeMissionGetTravelerName()
        {
            string messageBoxText =
                "Enter your name user name.\n" +
                " \n" +
                "Please use the name you wish to be referred during your mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Player gameTraveler)
        {
            string messageBoxText =
                $"Very good then, we will call you {gameTraveler.Name} on this mission.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerRace(Player gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your Wizarding World identifier on this mission.\n" +
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

        public static string InitializeMissionEchoTravelerInfo(Player gameTraveler)
        {
            string messageBoxText =
                $"Very good then {gameTraveler.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tUser Name: {gameTraveler.Name}\n" +
                $"\tUser Age: {gameTraveler.Age}\n" +
                $"\tUser Identifier: {gameTraveler.Race}\n" +
                " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Player gameTraveler)
        {
            string messageBoxText =
                $"\tUser Name: {gameTraveler.Name}\n" +
                $"\tUser Age: {gameTraveler.Age}\n" +
                $"\tUser Identifier: {gameTraveler.Race}\n" +
                " \n";

            return messageBoxText;
        }
        
        #endregion
    }
}
