﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        /// <summary>
        /// race type enum
        /// </summary>
        public enum RaceType
        {
            None,
            Witch,
            Wizard
        }

        #endregion

        #region FIELDS

        protected string _name;
        protected int _spaceTimeLocationID;
        protected int _age;
        protected RaceType _race;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int SpaceTimeLocationID
        {
            get { return _spaceTimeLocationID; }
            set { _spaceTimeLocationID = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// character
        /// </summary>
        public Character()
        {

        }

        /// <summary>
        /// character name/race
        /// </summary>
        /// <param name="name"></param>
        /// <param name="race"></param>
        /// <param name="spaceTimeLocationID"></param>
        public Character(string name, RaceType race, int spaceTimeLocationID)
        {
            _name = name;
            _race = race;
            _spaceTimeLocationID = spaceTimeLocationID;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
