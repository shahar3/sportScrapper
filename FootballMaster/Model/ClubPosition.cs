using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMaster.Model
{
    /// <summary>
    /// This class help us represent the currrent club position in the table
    /// </summary>
    class ClubPosition
    {
        private int points;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        private string clubName;

        public string ClubName
        {
            get { return clubName; }
            set { clubName = value; }
        }

        private int position;

        public int Position
        {
            get { return position; }
            set { position = value; }
        }


        public ClubPosition(int position ,string clubName, int points)
        {
            this.position = position;
            this.clubName = clubName;
            this.points = points;
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}",position,clubName,points);
        }
    }
}
