using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers_Repository
{
    public class Developer
    {
        public Developer()
        {

        }

        public int DeveloperId { get; set; }

        public string FullName { get; set; }

        public bool AccessToPluralsight { get; set; }

        public Developer(int developerId, string fullName, bool accessToPluralsight)
        {
            DeveloperId = developerId;
            FullName = fullName;
            AccessToPluralsight = accessToPluralsight;
        }
    }
}
