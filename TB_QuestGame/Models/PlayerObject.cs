using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class PlayerObject : GameObject
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public PlayerObjectType Type { get; set; }
        public string PickUpMessage { get; set; }
        public string PutDownMessage { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }
        public int ExperiencePoints { get; set; }
        public bool IsDeadly { get; set; }
        public event EventHandler ObjectAddedToInventory;
        
        /// <summary>
        /// objects added to the inventory
        /// </summary>
        public void OnObjectAddedToInventory()
        {
            if (ObjectAddedToInventory != null)
            {
                ObjectAddedToInventory(this, EventArgs.Empty);
            }
        }

        //
        // raise event when an object is added or removed from the inventory
        //
        private int _spaceTimeLocation;
        public override int SpaceTimeLocationId
        {
            get
            {
                return _spaceTimeLocation;
            }
            set
            {
                _spaceTimeLocation = value;
                if (value == 0)
                {
                    OnObjectAddedToInventory();
                }
            }
        }
    }
}


