using Developers_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeamRepo
    {
        private List<DevTeam> devTeamList = new List<DevTeam>();

        //Add Developer to a team
        public void AddDeveloperTeam(DevTeam devTeam)
        {
            devTeamList.Add(devTeam);
        }

        //List the teams
        public List<DevTeam> GetDevTeamList()
        {
            return devTeamList;
        }

        //Get team by Id
        public DevTeam GetTeamById(int teamId)
        {
            foreach(DevTeam devTeam in devTeamList)
            {
                if(devTeam.TeamId == teamId)
                {
                    return devTeam;
                }
            }
            return null;
        }

        //Add Developer to Team
        public bool AddDeveloperToTeam(int devTeamId, Developer Developer)
        {
            DevTeam devTeam = GetTeamById(devTeamId);
            if(devTeam != null)
            {
                devTeam.TeamMember.Add(Developer);
                return true;
            }
            return false;
        }

        //Add Developer List to team
        public bool AddDeveloperListToTeam(int devTeamId, List<Developer> developers)
        {
            DevTeam devTeam = GetTeamById(devTeamId);
            if(devTeam != null)
            {
                foreach(Developer developer in developers)
                {
                    devTeam.TeamMember.Add(developer);
                }
                return true;
            }
            return false;
        }

        //Remove Team
        public bool RemoveDevTeam(int teamId)
        {
            DevTeam devTeam = GetTeamById(teamId);
            if(devTeam != null)
            {
                int count = devTeamList.Count;
                devTeamList.Remove(devTeam);

                if(count > devTeamList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }

        //Update Team
        public bool UpdateTeam(int teamId, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamById(teamId);
            if(oldTeam != null)
            {
                oldTeam.TeamId = newTeam.TeamId;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamMember = newTeam.TeamMember;
                return true;
            }
            return false;
        }
    }
}
