using AutoMapper;
using Business.DTOs.SliderDTOs;
using Business.DTOs.TeamDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class TeamService : ITeamService
{
	private readonly ITeamRepository _teamRepository;
	private readonly IWebHostEnvironment _env;
	private readonly IMapper _mapper;

	public TeamService(ITeamRepository teamRepository, IWebHostEnvironment env, IMapper mapper)
	{
		_teamRepository = teamRepository;
		_env = env;
		_mapper = mapper;
	}

	public async Task AddTeamAsync(TeamCreateDTO teamCreateDTO)
	{
		if (teamCreateDTO.ImageFile == null) throw new EntityFileNotFoundException("Image file is required");


		Team team = _mapper.Map<Team>(teamCreateDTO);

		team.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/teams", teamCreateDTO.ImageFile, "team");

		await _teamRepository.AddEntityAsync(team);
		await _teamRepository.CommitAsync();
	}

	public void DeleteTeam(int id)
	{
		var existTeam = _teamRepository.GetEntity(x => x.Id == id);
		if (existTeam == null) throw new EntityNotFoundException("Team not found");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\teams", existTeam.ImageUrl);



		_teamRepository.DeleteEntity(existTeam);
		_teamRepository.Commit();
	}

	public List<TeamGetDTO> GetAllTeams(Func<Team, bool>? func = null)
	{
		var teams = _teamRepository.GetAllEntities(func);
		List<TeamGetDTO> teamGetDTOs = _mapper.Map<List<TeamGetDTO>>(teams);


		return teamGetDTOs;
	}

	public TeamGetDTO GetTeam(Func<Team, bool>? func = null)
	{
		var team = _teamRepository.GetEntity(func);
		TeamGetDTO teamGetDTO = _mapper.Map<TeamGetDTO>(team);

		return teamGetDTO;
	}

	public void ReturnTeam(int id)
	{
		var existTeam = _teamRepository.GetEntity(x => x.Id == id);
		if (existTeam == null) throw new EntityNotFoundException("Team not found!");


		_teamRepository.ReturnEntity(existTeam);

		_teamRepository.Commit();
	}

	public void SoftDelete(int id)
	{
		var existTeam = _teamRepository.GetEntity(x => x.Id == id);
		if (existTeam == null) throw new EntityNotFoundException("Team not found!");

		existTeam.DeletedDate = DateTime.UtcNow.AddHours(4);

		_teamRepository.SoftDelete(existTeam);

		_teamRepository.Commit();
	}

	public void UpdateTeam(TeamUpdateDTO updateDTO)
	{
		var oldTeam = _teamRepository.GetEntity(x => x.Id == updateDTO.Id);
		if (oldTeam == null) throw new EntityNotFoundException("Team not found");

		if (updateDTO.ImageFile != null)
		{

			Team team = _mapper.Map<Team>(updateDTO);

			team.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/teams", updateDTO.ImageFile, "team");
			Helper.DeleteFile(_env.WebRootPath, @"uploads\teams", oldTeam.ImageUrl);

			oldTeam.ImageUrl = team.ImageUrl;

		}

		oldTeam.FullName = updateDTO.FullName;
		oldTeam.Designation = updateDTO.Designation;
		oldTeam.UpdatedDate = DateTime.UtcNow.AddHours(4);


		_teamRepository.Commit();
	}
}
