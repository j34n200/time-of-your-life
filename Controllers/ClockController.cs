using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using time_of_your_life.Interfaces;
using time_of_your_life.Models;
using time_of_your_life.Models.DTO;

namespace time.Controllers;

[ApiController]
[Route("[controller]")]
public class ClockController : ControllerBase
{
    private static List<ClockProps> _presets = new List<ClockProps>() { new() };
    private readonly IPresetRepository _presetRepository;
    private readonly ILogger<ClockController> _logger;
    private readonly IMapper _mapper;

    public ClockController(
        ILogger<ClockController> logger,
        IPresetRepository presetRepository,
        IMapper mapper)
    {
        _logger = logger;
        _presetRepository = presetRepository;
        _mapper = mapper;
    }

    [HttpGet, Route("presets")]
    public async Task<IEnumerable<ClockProps>> GetPresets()
    {
        return _presetRepository.GetPresets();
    }

    [HttpGet, Route("presets/{id}")]
    public IActionResult GetPresetById(Guid id)
    {
        var preset = _presetRepository.GetPresetById(id);
        if (preset == null)
        {
            _logger.LogError($"Preset with id {id} not found.");
            return NotFound();
        }

        return Ok(preset);
    }
    [HttpPost("presets")]
    public async Task<IActionResult> AddPreset([FromBody] CreateClockPropsDTO preset)
    {
        var presetObj = _mapper.Map<ClockProps>(preset);

        if (ModelState.IsValid)
        {
            await _presetRepository.AddPreset(presetObj);
            _logger.LogInformation("Preset successfuly created.");
        }
        else
        {
            _logger.LogError("Preset structure is not valid.");
            return BadRequest(ModelState);
        }

        return Ok(preset);
    }

    [HttpPut("presets/{id}")]
    public async Task<IActionResult> UpdatePreset([FromBody] UpdateClockPropsDTO presetDTO, Guid id)
    {
        if (ModelState.IsValid)
        {
            var presetObj = _presetRepository.GetPresetById(id);
            if (presetObj == null)
            {
                _logger.LogError($"Preset with id {id} not found.");
                return NotFound();
            }
            _mapper.Map<UpdateClockPropsDTO, ClockProps>(presetDTO, presetObj);
            await _presetRepository.UpdatePreset(_mapper.Map<ClockProps>(presetObj));
            _logger.LogInformation($"Preset with id {id} successfuly updated.");
            return Ok(presetObj);
        }
        else
        {
            _logger.LogError("Preset structure is not valid.");
            return BadRequest(ModelState);
        }
    }
}
