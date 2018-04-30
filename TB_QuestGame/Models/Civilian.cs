using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// civilian class
    /// </summary>
    public class Civilian : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public List<string> Messages { get; set; }
        private int _experiencePoints;

        public bool IsDeadly { get; set; }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Value { get; set; }
        
        ///<summary>
        /// generate a message or use default
        /// </summary>
        /// <returns> message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return $"My name is {base.Name} and I am a {base.Race}";
            }
        }

        ///<summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns> message text</returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
