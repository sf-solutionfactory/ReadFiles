using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadMail.IEntities
{
    public class nombres
    {

        private string _name = string.Empty;
        private string _upper = string.Empty;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string upper
        {
            get { return _upper; }
            set { _upper = value; }
        }


    }

}
