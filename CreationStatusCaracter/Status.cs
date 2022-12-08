using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationStatusCaracter
{
    public class Status
    {
        private string _name;
        private int _age;
        private string _class;

        public int Strength;
        public int Dex;
        public int Intelligence;
        public int Constitution;
        public int Charisma;

        public string Name
        {
            get { return _name; }
            set {
                if(value != null && value.Length > 1)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", ("Name must have more characters."));
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 16)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value",
                        string.Format("Age must be higher than or equal to {0}.", 16)
                    );
                }
            }
        }

        public string Class
        {
            get { return _class; }
            set
            {
                if (value != null && value.Length > 1)
                {
                    _class = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", ("Class must have more characters."));
                }
            }
        }
    }
}
