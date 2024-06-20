using AutoMapper;
using Business.DTOs.TeamDTOs;
using Business.Exceptions;
using Business.Extensions;
using Business.Service.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace TechnoStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeamController : Controller
	{
		private readonly ITeamService _teamService;
		private readonly IMapper _mapper;


		public TeamController(ITeamService teamService, IMapper mapper)
		{
			_teamService = teamService;
			_mapper = mapper;
		}

		public IActionResult Index(int page = 1)
		{
			var teams = _teamService.GetAllTeams(x => x.IsDeleted == false);
			List<Team> teamGetDTOs = _mapper.Map<List<Team>>(teams);

			var paginatedDatas = PaginatedList<Team>.Create(teamGetDTOs, 2, page);
			return View(paginatedDatas);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(TeamCreateDTO teamCreateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				await _teamService.AddTeamAsync(teamCreateDTO);
			}
			catch (FileContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (FileSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (EntityFileNotFoundException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var existTeam = _teamService.GetTeam(x => x.Id == id);

			if (existTeam == null) return NotFound();

			TeamUpdateDTO teamUpdateDTO = new TeamUpdateDTO
			{
				Id = existTeam.Id,
				FullName = existTeam.FullName,
				Designation = existTeam.Designation
			};




			return View(teamUpdateDTO);
		}

		[HttpPost]
		public IActionResult Update(TeamUpdateDTO teamUpdateDTO)
		{
			if (!ModelState.IsValid)
				return View();

			try
			{
				_teamService.UpdateTeam(teamUpdateDTO);
			}
			catch (FileContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (FileSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return RedirectToAction("Index");
		}


		public IActionResult Delete(int id)
		{
			try
			{
				_teamService.DeleteTeam(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}
			catch (EntityFileNotFoundException ex)
			{
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		public IActionResult SoftDelete(int id)
		{
			try
			{
				_teamService.SoftDelete(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}

			return RedirectToAction("Index");
		}
		public IActionResult Return(int id)
		{
			try
			{
				_teamService.ReturnTeam(id);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound();
			}

			return RedirectToAction("Index");
		}

		public IActionResult Archive()
		{
			var teams = _teamService.GetAllTeams(x => x.IsDeleted == true);

			return View(teams);
		}
	}
}
