using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravityOne.Gravity
{
    class Recording
    {
        string name;
        string fileName;
        DateTime date;
        int numberOfObjects;
        string calcsDone;
        string displayText;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int NumberOfObjects
        {
            get
            {
                return numberOfObjects;
            }

            set
            {
                numberOfObjects = value;
            }
        }

        public string CalcsDone
        {
            get
            {
                return calcsDone;
            }

            set
            {
                calcsDone = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public string DisplayText
        {
            get
            {
                return displayText;
            }

            set
            {
                displayText = value;
            }
        }
    }
}
