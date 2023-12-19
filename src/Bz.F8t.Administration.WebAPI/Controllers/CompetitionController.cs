using Bz.F8t.Administration.Application.Competitions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bz.F8t.Administration.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompetitionController(ICompetitionService competitionService) : ControllerBase
{
    private readonly ICompetitionService _competitionService = competitionService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody]CreateCompetitionDto dto)
    {
        var id = await _competitionService.CreateCompetitionAsync(dto);
        return CreatedAtAction(nameof(GetAsync), new { id }, null);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(CompetitionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(Guid id)
    { 
        var dto = await _competitionService.GetCompetitionAsync(id);
        return Ok(dto);
    }

    [HttpPost("{id:Guid}/Registration/Open")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> OpenRegistrationAsync(Guid id)
    {
        await _competitionService.OpenRegistrationAsync(id);
        return NoContent();
    }

    [HttpPost("{id:Guid}/Registration/Complete")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CompleteRegistrationAsync(Guid id)
    {
        await _competitionService.CompleteRegistrationAsync(id);
        return NoContent();
    }

    [HttpPatch("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ChangeMaxCompetitors(Guid id, [FromBody]ChangeMaxCompetitorsRequestDto dto)
    {
        await _competitionService.ChangeMaxCompetitors(id, dto.MaxCompetitors);
        return NoContent();
    }

    [HttpPost("{id:Guid}/Checkpoints")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AddCheckpoint(Guid id, [FromBody] AddCheckpointRequestDto dto)
    {
        await _competitionService.AddCheckpoint(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:Guid}/Checkpoints/{checkpointId:Guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveCheckpoint(Guid id, Guid checkpointId)
    {
        await _competitionService.RemoveCheckpoint(id, checkpointId);
        return NoContent();
    }
}
