using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all locations, game, and NPC Objects
        //
        private List<SpaceTimeLocation> _spaceTimeLocations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;
        
        public List<SpaceTimeLocation> SpaceTimeLocations
        {
            get { return _spaceTimeLocations; }
            set { _spaceTimeLocations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }
        
        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }


        #endregion

        #region ***** constructor *****

        ///<summary>
        /// default Universe constructor
        ///</summary>
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the locations
        /// </summary>
        private void IntializeUniverse()
        {
            _spaceTimeLocations = UniverseObjects.SpaceTimeLocations;
            _gameObjects = UniverseObjects.gameObjects;
            _npcs = UniverseObjects.Npcs;
        }

        /// <summary>
        /// validate player object by location ID
        /// </summary>
        /// <param name="traverObjectId"></param>
        /// <param name="currentSpaceTimeLocation"></param>
        /// <returns></returns>
        public bool IsValidPlayerObjectByLocationId(int traverObjectId, int currentSpaceTimeLocation)
        {
            List<int> playerObjectIds = new List<int>();

            //
            // create a list of player object ids in current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == currentSpaceTimeLocation && gameObject is PlayerObject)
                {
                    playerObjectIds.Add(gameObject.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (playerObjectIds.Contains(traverObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if the Space-Time Location Id is valid
        /// </summary>
        /// <param name="spaceTimeLocationId">true if Space-Time Location exists</param>
        /// <returns></returns>
        public bool IsValidSpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<int> spaceTimeLocationIDs = new List<int>();

            //
            // create a list of location ids
            //
            foreach (SpaceTimeLocation stl in _spaceTimeLocations)
            {
                spaceTimeLocationIDs.Add(stl.SpaceTimeLocationID);
            }

            //
            // determine if thelocation id is a valid id and return the result
            //
            if (spaceTimeLocationIDs.Contains(spaceTimeLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="spaceTimeLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int spaceTimeLocationId)
        {
            SpaceTimeLocation spaceTimeLocation = GetSpaceTimeLocationById(spaceTimeLocationId);
            if (spaceTimeLocation.Accessible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the next available ID for a location object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        public int GetMaxSpaceTimeLocationId()
        {
            int MaxId = 0;

            foreach (SpaceTimeLocation spaceTimeLocation in SpaceTimeLocations)
            {
                if (spaceTimeLocation.SpaceTimeLocationID > MaxId)
                {
                    MaxId = spaceTimeLocation.SpaceTimeLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a location object using an Id
        /// </summary>
        /// <param name="Id">location ID</param>
        /// <returns>requested location</returns>
        public SpaceTimeLocation GetSpaceTimeLocationById(int Id)
        {
            SpaceTimeLocation spaceTimeLocation = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (SpaceTimeLocation location in _spaceTimeLocations)
            {
                if (location.SpaceTimeLocationID == Id)
                {
                    spaceTimeLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spaceTimeLocation == null)
            {
                string feedbackMessage = $"The Location ID {Id} does not exist in the current Universe.";
            }

            return spaceTimeLocation;
        }

        ///<summary>
        /// initialize game objects
        /// </summary>
        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentSpaceTimeLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object ids in current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == currentSpaceTimeLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        /// get the game objects by location IDs
        ///</summary>
        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw an exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return gameObjectToReturn;
        }

        /// <summary>
        /// get objects by locations IDs
        /// </summary>
        /// <param name="spaceTimeLocationId"></param>
        /// <returns></returns>
        public List<GameObject> GetGameObjectByLocationId(int spaceTimeLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the ame object list and grab all that are in the current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == spaceTimeLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        /// <summary>
        /// get player object by location ID
        /// </summary>
        /// <param name="spaceTimeLocationId"></param>
        /// <returns></returns>
        public List<PlayerObject> GetPlayerObjectsByLocationId(int spaceTimeLocationId)
        {
            List<PlayerObject> playerObjects = new List<PlayerObject>();

            //
            // run through the game object list and grab all that are in the current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == spaceTimeLocationId && gameObject is PlayerObject)
                {
                    playerObjects.Add(gameObject as PlayerObject);
                }
            }

            return playerObjects;
        }

        ///<summary>
        /// get the player's inventory
        /// </summary>
        public List<PlayerObject> PlayerInventory()
        {
            List<PlayerObject> inventory = new List<PlayerObject>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.SpaceTimeLocationId == 0)
                {
                    inventory.Add(gameObject as PlayerObject);
                }
            }

            return inventory;
        }

        /// <summary>
        /// validate the NPC by location ID
        /// </summary>
        /// <param name="npcId"></param>
        /// <param name="currentPlaceTimeLocation"></param>
        /// <returns></returns>
        public bool IsValidNpcByLocationId(int npcId, int currentPlaceTimeLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // create a list of NPC ids in current locations
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.SpaceTimeLocationID == currentPlaceTimeLocation)
                {
                    npcIds.Add(npc.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get NPC object by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Npc GetNpcObjectById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the correct one
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return npcToReturn;
        }

        /// <summary>
        /// get NPC by Location ID
        /// </summary>
        /// <param name="LocationId"></param>
        /// <returns></returns>
        public List<Npc> GetNpcsByLocationId(int LocationId)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // run through the NPC object list and grab all that are in the current space-time location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.SpaceTimeLocationID == LocationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        /// <summary>
        /// get an NPC object using an ID
        /// </summary>
        /// <param name="Id">NPC object ID</param>
        /// <returns>requested NPC object</returns>
        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the correct one
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return npcToReturn;
        }

        #endregion
    }
}
