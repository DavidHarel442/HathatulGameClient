using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public  class Players
    {// this class is incharge of managing the details and infomation of each player

        /// <summary>
        /// this property contains the name of the player
        /// </summary>
        private string name;
        /// <summary>
        /// this property contains the sit of the player
        /// </summary>
        private int sit;
        /// <summary>
        /// this property contains the value of whether it is the last turn of the game for the player
        /// </summary>
        private bool isLastTurn  = false;

        /// <summary>
        /// getter and setters of the 'name' property
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// getter and setters of the 'sit' property
        /// </summary>
        public int Sit { get => sit; set => sit = value; }
        /// <summary>
        /// getter and setters of the 'isLastTurn' property
        /// </summary>
        public bool IsLastTurn { get => isLastTurn; set => isLastTurn = value; }

        /// <summary>
        /// constructor. recieves 'name' and 'sit' and equals it to the properties 'name' and 'sit'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sit"></param>
        public Players(string name, int sit) 
        { 
            this.name = name;
            this.sit = sit;
        }

    }
}
