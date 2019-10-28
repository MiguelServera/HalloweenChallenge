using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsProject
{
    public class Films
    {
        public string title { get; set; }
        public string description { get; set; }
        public string FullInfo
        {
            get
            {
                return title;
            }
        }
        public string FullDesc
        {
            get
            {
                return description;
            }
        }
    }
}
