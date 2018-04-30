using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;
        private bool _playingGame;
        private SpaceTimeLocation _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// set up the controller, initialize the game, and manage the game loop
        /// </summary>
        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            PlayerObject playerObject;
            _playingGame = true;

            //
            // add the event handler for adding/subtracting to/from inventory
            //
            foreach (GameObject gameObject in _gameUniverse.GameObjects)
            {
                if (gameObject is PlayerObject)
                {
                    playerObject = gameObject as PlayerObject;
                    playerObject.ObjectAddedToInventory += HandleObjectAddedToInventory;
                }
            }

            //
            // add initial items to the player's inventory
            //

            PlayerObject playerObject1 = _gameUniverse.GetGameObjectById(2) as PlayerObject;
            PlayerObject playerObject2 = _gameUniverse.GetGameObjectById(3) as PlayerObject;
            PlayerObject playerObject3 = _gameUniverse.GetGameObjectById(4) as PlayerObject;
            playerObject1.SpaceTimeLocationId = 0;
            playerObject2.SpaceTimeLocationId = 0;
            playerObject3.SpaceTimeLocationId = 0;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission player
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                playerActionChoice = GetNextPlayerAction();
                
                //
                // choose an action based on the user's menu choice
                //
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.ListLocations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case PlayerAction.LookAt:
                        LookAtAction();
                        break;

                    case PlayerAction.Travel:
                        //
                        // get new location choice and update the current location property
                        //                        
                        _gamePlayer.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextLocation();
                        _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gamePlayer.SpaceTimeLocationID);

                        //
                        // display the new space-time location info
                        //
                        _gameConsoleView.DisplayCurrentLocationInfo();
                        break;

                    case PlayerAction.PickUp:
                        PickUpAction();
                        break;

                    case PlayerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case PlayerAction.LocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case PlayerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case PlayerAction.PutDown:
                        PutDownAction();
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.ListNonplayerCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case PlayerAction.PlayerMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Traveler Menu", "Select an operation from the menu.", ActionMenu.PlayerMenu, "");
                        break;

                    case PlayerAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu", ActionMenu.ObjectMenu, "");
                        break;

                    case PlayerAction.NonplayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
                        break;

                    case PlayerAction.TalkTo:
                        TalkToAction();
                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Race = player.Race;
            _gamePlayer.SpaceTimeLocationID = 1;

            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;
        }

        /// <summary>
        /// update the game status
        /// </summary>
        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocation.SpaceTimeLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gamePlayer.LocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

                //
                // update experience points for visiting locations
                //
                _gamePlayer.ExperiencePoints += _currentLocation.ExperiencePoints;

            }
        }

        /// <summary>
        /// show the game objects
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of player objects in location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                if (gameObjectToLookAtId != 0)
                {
                    //
                    // get the game object from the universe
                    //
                    GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                    //
                    // display infomation for the object chosen
                    //
                    _gameConsoleView.DisplayGameObjectInfo(gameObject);
                }
            }
        }

        /// <summary>
        /// pick up actions
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of player objects in location and get a player choice
            //
            int playerObjectToPickUpId = _gameConsoleView.DisplayGetPlayerObjectToPickUp();

            //
            // add the player object to player's inventory
            //
            if (playerObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                PlayerObject playerObject = _gameUniverse.GetGameObjectById(playerObjectToPickUpId) as PlayerObject;
                
                //
                // note: player object is added to list and the location is set to 0
                //
                playerObject.SpaceTimeLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmPlayerObjectAddedToInventory(playerObject);

                //
                // update experience points for adding objects
                //
                _gamePlayer.ExperiencePoints += _gamePlayer.ExperiencePoints;

                //
                // add life if health greater than 100
                //
                if (_gamePlayer.Health >= 100)
                {
                    _gamePlayer.Health = 100;
                    _gamePlayer.Lives += 1;
                }
            }
        }

        /// <summary>
        /// put objects down
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of player objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            PlayerObject playerObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as PlayerObject;

            //
            // remove the object from inventory and set the location to the current value
            //
            playerObject.SpaceTimeLocationId = _gamePlayer.SpaceTimeLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmPlayerObjectRemovedFromInventory(playerObject);
        }

        ///<summary>
        /// this method tests and casts all appropriate game objects to player objects
        /// </summary>
        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(PlayerObject))
            {
                PlayerObject playerObject = gameObject as PlayerObject;
                switch (playerObject.Type)
                {
                    case PlayerObjectType.Medicine:
                        _gamePlayer.Health += playerObject.Value;

                        //
                        // add life if health greater than 100
                        //
                        if (_gamePlayer.Health >= 100)
                        {
                            _gamePlayer.Health = 100;
                            _gamePlayer.Lives += 1;
                        }

                        //
                        // remove object from game
                        //
                        if (playerObject.IsConsumable)
                        {
                            playerObject.SpaceTimeLocationId = -1;
                        }

                        //
                        // remove life if poisoned
                        //
                        if (playerObject.IsDeadly)
                        {
                            _gamePlayer.Lives -= 1;
                        }
                        break;
                    case PlayerObjectType.Weapon:
                        _gamePlayer.ExperiencePoints += playerObject.Value;
                        
                        //
                        // remove object from game
                        //
                        if (playerObject.IsConsumable)
                        {
                            playerObject.SpaceTimeLocationId = -1;
                        }

                        //
                        // remove life if poisoned
                        //
                        if (playerObject.IsDeadly)
                        {
                            _gamePlayer.Lives -= 1;
                        }
                        break;
                    case PlayerObjectType.Potion:
                        _gamePlayer.Health += playerObject.Value;

                        //
                        // add life if health greater than 100
                        //
                        if (_gamePlayer.Health >= 100)
                        {
                            _gamePlayer.Health = 100;
                            _gamePlayer.Lives += 1;
                        }

                        //
                        // remove object from game
                        //
                        if (playerObject.IsConsumable)
                        {
                            playerObject.SpaceTimeLocationId = -1;
                        }

                        //
                        // remove life if poisoned
                        //
                        if (playerObject.IsDeadly)
                        {
                            _gamePlayer.Lives -= 1;
                        }
                        break;
                    case PlayerObjectType.Information:
                        _gamePlayer.ExperiencePoints += playerObject.Value;
                        
                        //
                        // remove object from game
                        //
                        if (playerObject.IsConsumable)
                        {
                            playerObject.SpaceTimeLocationId = -1;
                        }

                        //
                        // remove life if poisoned
                        //
                        if (playerObject.IsDeadly)
                        {
                            _gamePlayer.Lives -= 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// display the correct menu/sub-menu and get the next player action
        /// </summary>
        /// <returns>player action</returns>
        private PlayerAction GetNextPlayerAction()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.PlayerMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return playerActionChoice;
        }

        /// <summary>
        /// process the talk to action
        /// </summary>
        private void TalkToAction()
        {
            //
            // display a list of NPCs in location and get a player choice
            //
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            //
            // display NPC's message
            //
            if (npcToTalkToId != 0)
            {
                //
                // get the NPC from the universe
                //
                Npc npc = _gameUniverse.GetNpcById(npcToTalkToId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayTalkTo(npc);

                //
                // add life 
                //
                if (_gamePlayer.Lives > 1)
                {
                    _gamePlayer.Lives++;
                }

                //
                // update experience points for adding objects
                //
                Civilian civilian = npc as Civilian;
                _gamePlayer.ExperiencePoints += civilian.ExperiencePoints;
            }
        }

        #endregion
    }
}
