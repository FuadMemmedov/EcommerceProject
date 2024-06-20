using Business.DTOs.TeamDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface ITeamService
{
	Task AddTeamAsync(TeamCreateDTO teamCreateDTO);
	void DeleteTeam(int id);
	void SoftDelete(int id);
	void ReturnTeam(int id);
	void UpdateTeam(TeamUpdateDTO updateDTO);
	TeamGetDTO GetTeam(Func<Team, bool>? func = null);
	List<TeamGetDTO> GetAllTeams(Func<Team, bool>? func = null);
}
