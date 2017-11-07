using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityOne.Gravity
{
    class Message
    {
        string text;
        int time;

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                time = 300;
            }
        }

        public int Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }
    }
}
