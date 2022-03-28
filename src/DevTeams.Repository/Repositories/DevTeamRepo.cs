using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DevTeamRepo
{
    private readonly List<DevTeam> _devTeamsDatabase = new List<DevTeam>();
    private DeveloperRepo _developerRepo;
    private int _count;

    public DevTeamRepo(DeveloperRepo developerRepo)
    {
        _developerRepo = developerRepo;
    }

    //* Create
    public bool CreateTeam(DevTeam devTeam)
        {
            if (devTeam != null)
            {
                _count++;
                devTeam.TeamID =_count;
                _devTeamsDatabase.Add(devTeam);
                return true;
            }
            else
            {
                return false;
            } 
        }
    public bool AddDevTeamToList(DevTeam team)
    {
        if (team != null)
        {
            _count++;
            team.TeamID = _count;
            _devTeamsDatabase.Add(team);
            return true;
        }
        else
        {
            return false;
        }
    }

    //* Read
    public List<DevTeam> GetDevTeamsList()
    {
        return _devTeamsDatabase;
    }

    public DevTeam GetDevTeamsByID(int id)
    {
        foreach (var team in _devTeamsDatabase)
        {
            if (team.TeamID == id)
            {
                return team;
            }
        }
        return null;
    }


    //* Update
    public bool RemoveDevTeamFromList(int id)
    {
        var team = GetDevTeamsByID(id);
        if (team == null)
        {
            return false;
        }

        int initialCount = _devTeamsDatabase.Count;
        _devTeamsDatabase.Remove(team);

        if (initialCount > _devTeamsDatabase.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //* Delete
}