using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class PlayerObject : GameObject
    {
        private int _experiencePoints;

        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int SpaceTimeLocationId { get; set; }
        public PlayerObjectType Type { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }
        public int ExperiencePoints { get; set; }
        public bool IsDeadly { get; set; }

    }
}


