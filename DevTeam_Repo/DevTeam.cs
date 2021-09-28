using Developers_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeam
    {
        public DevTeam() { }
        public List<Developer> TeamMember { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }

        public DevTeam(List<Developer> teamMember, string teamName, int teamId)
        {
            TeamMember = teamMember;
            TeamName = teamName;
            TeamId = teamId;
        }
    }
}
