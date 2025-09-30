using Application.Abstractions;
using Domain.Entities;
using Domain.Enums;
//using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainsController : ControllerBase
{
    private readonly ITrainRepository _repo;
    private readonly IUnitOfWork _uow;

            
    public TrainsController(ITrainRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    [HttpPost("smoke")]
    public async Task<IActionResult> Smoke(CancellationToken ct)
    {
        // Add
        //var id = Guid.NewGuid();
        var entity = Train.Create("73273", TrainType.Passenger);
        //entity.Id = id; // Find same post
        var id = entity.Id;
        await _repo.AddAsync(entity);
        await _uow.SaveChangesAsync();

        // Update
        entity.UpdateTrainNumber("73274");
        await _repo.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync();

        // Remove
        await _repo.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        // Verify it is gone
        var existsAfterDelete = await _repo.GetByIdAsync(id, ct) is not null;

        return Ok(new
        {
            CreateId = id,
            FinalExists = existsAfterDelete, // Should be false
            Message = "Add->Update->Remove sequence excuted."
        });


    }

    [HttpGet]
    public async Task<IReadOnlyList<Train>> GetAll() => await _repo.ListAsync();


}
