using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        /// <summary>
        /// view status enum
        /// </summary>
        private enum ViewStatus
        {
            PlayerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gamePlayer;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, Universe gameUniverse)
        {
            _gamePlayer = gamePlayer;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.PlayerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction choosenAction = PlayerAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // validate menu choices
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate on range if either min value and max value are not e
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }
            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @" __    __                                  _____           _       _                      ");
            Console.WriteLine(tabSpace + @"|  |  |  |                                |  ___ \        | |     | |                     ");
            Console.WriteLine(tabSpace + @"|  |__|  |   ___    ___    ___   _     _  | (___) |      _| |_   _| |_   ___   ___        ");
            Console.WriteLine(tabSpace + @"|   __   |  / _ \  | _ \  | _ \ | |   | | |   ___/  __  |_   _| |_   _| / _ \ | _ \       ");
            Console.WriteLine(tabSpace + @"|  |  |  | | /_\ | |(_)/  |(_)/ \ \   / / |  |     |  |   | |     | |   | __/ |(_)/       ");
            Console.WriteLine(tabSpace + @"|__|  |__| |_| |_| |_|\_\ |_|\_\ \ \_/ /  |__|     |__|   |_|     |_|   \___| |_|\_\      ");
            Console.WriteLine(tabSpace + @"                                  \   /                                                   ");
            Console.WriteLine(tabSpace + @"                               ____| /                                                    ");
            Console.WriteLine(tabSpace + @"                              |_____/                                                     ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Harry Potter: The Sorcerer's Stone";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }
        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePlayer, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>player object with all properties updated</returns>
        public Player GetInitialPlayerInfo()
        {
            Player player = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get player's name
            //
            DisplayGamePlayScreen("Mission Initialization - Name", Text.InitializeMissionGetPlayerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            player.Name = GetString();

            //
            // get player's age
            //
            DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetPlayerAge(player), ActionMenu.MissionIntro, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            player.Age = gamePlayerAge;

            //
            // get player's race
            //
            DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetPlayerRace(player), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your race {player.Name}: ");
            player.Race = GetRace();

            //
            // echo the player's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoPlayerInfo(player), ActionMenu.MissionIntro, "");
            GetContinueKey();

            _viewStatus = ViewStatus.PlayingGame;

            return player;
        }

        /// <summary>
        /// show the current location info
        /// </summary>
        public void DisplayCurrentLocationInfo()
        {
            SpaceTimeLocation currentSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentSpaceTimeLocation), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// display and get next locations
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNextLocation()
        {
            int spaceTimeLocationId = 0;
            bool validSpaceTimeLocationId = false;

            DisplayGamePlayScreen("Travel to a Chamber", Text.Travel(_gamePlayer, _gameUniverse.SpaceTimeLocations), ActionMenu.MainMenu, "");

            while (!validSpaceTimeLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new chamber {_gamePlayer.Name}: ", 1, _gameUniverse.GetMaxSpaceTimeLocationId(), out spaceTimeLocationId);

                //
                // validate integer as a valid location ID and determine accessibility
                //
                if (_gameUniverse.IsValidSpaceTimeLocationId(spaceTimeLocationId))
                {
                    if (_gameUniverse.IsAccessibleLocation(spaceTimeLocationId))
                    {
                        validSpaceTimeLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible chamber. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid chamber ID. Please try again.");
                }
            }

            return spaceTimeLocationId;
        }

        #region ----- display responses to menu action choices -----

        /// <summary>
        /// display the game objects' info
        /// </summary>
        /// <param name="gameObject"></param>
        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// display player info
        /// </summary>
        public void DisplayPlayerInfo()
        {
            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_gamePlayer), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// display list of game objects
        /// </summary>
        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display list of locations
        /// </summary>
        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("List: Locations", Text.ListLocations(_gameUniverse.SpaceTimeLocations), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display current inventory
        /// </summary>
        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameUniverse.PlayerInventory()), ActionMenu.PlayerMenu, "");
        }

        ///<summary>
        /// display look around
        /// </summary>
        public void DisplayLookAround()
        {
            //
            // get current location
            //
            SpaceTimeLocation currentSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);

            //
            // get list of game objects in current location
            //
            List<GameObject> gameObjectsInCurrentSpaceTimeLocation = _gameUniverse.GetGameObjectByLocationId(_gamePlayer.SpaceTimeLocationID);

            //
            // get list of NPCs in current location
            //
            List<Npc> npcsInCurrentSpactTimeLocation = _gameUniverse.GetNpcsByLocationId(_gamePlayer.SpaceTimeLocationID);

            string messageBoxText = Text.LookAround(currentSpaceTimeLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentSpaceTimeLocation);
            messageBoxText += Text.NpcsChooseList(npcsInCurrentSpactTimeLocation);

            DisplayGamePlayScreen("Current Location", Text.LookAround(currentSpaceTimeLocation), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// display locations visited to the user
        /// </summary>
        public void DisplayLocationsVisited()
        {
            //
            // generate a list of locations that have been visited
            //
            List<SpaceTimeLocation> visitedSpaceTimeLocations = new List<SpaceTimeLocation>();
            foreach (int spaceTimeLocationId in _gamePlayer.LocationsVisited)
            {
                visitedSpaceTimeLocations.Add(_gameUniverse.GetSpaceTimeLocationById(spaceTimeLocationId));
            }

            DisplayGamePlayScreen("Chambers Visited", Text.VisitedLocations(visitedSpaceTimeLocations), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// show the get game object to look at
        /// </summary>
        /// <returns></returns>
        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of game objects in the current location
            //
            List<GameObject> gameObjectsInSpaceTimeLocation = _gameUniverse.GetGameObjectByLocationId(_gamePlayer.SpaceTimeLocationID);

            if (gameObjectsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInSpaceTimeLocation), ActionMenu.ObjectMenu, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the user
                    //
                    GetInteger($"Enter the ID number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gamePlayer.SpaceTimeLocationID))
                    {
                        validGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object ID. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// display the player objects to collect
        /// </summary>
        /// <returns></returns>
        public int DisplayGetPlayerObjectToPickUp()
        {
            int gameObjectsId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of player objects in the current location
            //
            List<PlayerObject> playerObjectsInLocation = _gameUniverse.GetPlayerObjectsByLocationId(_gamePlayer.SpaceTimeLocationID);

            if (playerObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(playerObjectsInLocation), ActionMenu.ObjectMenu, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the ID number of the onject you wish to add to your inventory: ", 0, 0, out gameObjectsId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidPlayerObjectByLocationId(gameObjectsId, _gamePlayer.SpaceTimeLocationID))
                    {
                        PlayerObject playerObject = _gameUniverse.GetGameObjectById(gameObjectsId) as PlayerObject;
                        if (playerObject.CanInventory)
                        {
                            validGamerObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object ID. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }
            return gameObjectsId;
        }

        /// <summary>
        /// display the information required for the player to choose an object to pick up
        /// </summary>
        /// <returns>game object Id</returns>
        public int DisplayGetInventoryObjectToPutDown()
        {
            int playerObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gameUniverse.PlayerInventory().Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameUniverse.PlayerInventory()), ActionMenu.ObjectMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out playerObjectId);

                    //
                    // find object in inventory
                    // note: LINQ used, but a foreach loop may also be used 
                    //
                    PlayerObject objectToPutDown = _gameUniverse.PlayerInventory().FirstOrDefault(o => o.Id == playerObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.ObjectMenu, "");
            }

            return playerObjectId;
        }

        /// <summary>
        /// confirm removing inventory objects
        /// </summary>
        /// <param name="objectRemovedFromInventory"></param>
        public void DisplayConfirmPlayerObjectRemovedFromInventory(PlayerObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// confirm object added to inventory
        /// </summary>
        /// <param name="objectAddedToInventory">game object</param>
        public void DisplayConfirmPlayerObjectAddedToInventory(PlayerObject objectAddedToInventory)
        {
            if (objectAddedToInventory.PickUpMessage != null)
            {
                DisplayGamePlayScreen("Pick Up Game Object", objectAddedToInventory.PickUpMessage, ActionMenu.ObjectMenu, "");
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory} has been added to your inventory.", ActionMenu.ObjectMenu, "");
            }
        }

        /// <summary>
        /// display the list NPCs Objects
        /// </summary>
        public void DisplayListOfAllNpcObjects()
        {
            DisplayGamePlayScreen("List: NPC Objects", Text.ListAllNpcObjects(_gameUniverse.Npcs), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display get the NPC to talk to
        /// </summary>
        /// <returns>NPC Id</returns>
        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            //
            // get a list of NPCs in the current location
            //
            List<Npc> npcsInSpaceTimeLocation = _gameUniverse.GetNpcsByLocationId(_gamePlayer.SpaceTimeLocationID);

            if (npcsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NpcsChooseList(npcsInSpaceTimeLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the character you wish to speak with: ", 0, 0, out npcId);

                    //
                    // validate integer as a valid NPC id and in current location
                    //
                    if (_gameUniverse.IsValidNpcByLocationId(npcId, _gamePlayer.SpaceTimeLocationID))
                    {
                        Npc npc = _gameUniverse.GetNpcById(npcId);
                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        }

        /// <summary>
        /// display the message from the NPC
        /// </summary>
        /// <param name="npc">speaking NPC</param>
        public void DisplayTalkTo(Npc npc)
        {
            ISpeak speakingNpc = npc as ISpeak;

            string message = speakingNpc.Speak();

            if (npc is ISpeak)
            {
                speakingNpc.Speak();
            }
            else if (message == "")
            {
                message = "It appears this character has nothing to say. Please try again.";
            }

            DisplayGamePlayScreen("Speak to Character", message, ActionMenu.NpcMenu, "");
        }

        #endregion

        #endregion
    }
}
