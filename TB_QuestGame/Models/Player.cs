using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES

        public enum Weapon
        {
            None,
            Wand,
            Potion,
            Logic,
            Broomstick
        }

        #endregion

        #region FIELDS

        private int _experiencePoints;
        private int _health;
        private int _lives;
        private List<int> _locationsVisited;

        #endregion

        #region PROPERTIES

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public List<int> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<int>();
        }

        public Player(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _locationsVisited = new List<int>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// has visited
        /// </summary>
        /// <param name="_spaceTimeLocationID"></param>
        /// <returns></returns>
        public bool HasVisited(int _spaceTimeLocationID)
        {
            if (LocationsVisited.Contains(_spaceTimeLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
