using Calculator.API.Domain.Models;
using Calculator.API.Domain.Repositories;
using Calculator.API.Resources;

namespace Calculator.API.Services.Impl;

public class PositionService : IPositionService  {
    private readonly IPositionRepository _positionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PositionService(IPositionRepository positionRepository, IUnitOfWork unitOfWork) 
    {
        _positionRepository = positionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(AddPositionResource positionResource) {
        Position position = new Position
        {
            Id = Guid.NewGuid(),
            Description = positionResource.Description
        };

        try
        {
            await _positionRepository.AddAsync(position);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception) 
        {
            return;
        }
    }

    public async Task<List<PositionResource>> GetAllAsync() {
        List<Position> positions = await _positionRepository.GetAllAsync();
        List<PositionResource> positionResources = positions.Select(p => new PositionResource
        {
            Id = p.Id,
            GenId = p.GenId,
            Description = p.Description
        }).ToList();

        return positionResources;
    }

    
    public async Task<PositionResource?> GetByIdAsync(Guid positionId) {
        Position? position = await _positionRepository.GetByIdAsync(positionId);

        if (position == null) return null;

        PositionResource resource = new PositionResource
        {
            Id = position.Id,
            GenId = position.GenId,
            Description = position.Description
        };

        return resource;
    }

    public async Task Update(Guid positionId, UpdatePositionResource resource) {
        Position? position = await _positionRepository.GetByIdAsync(positionId);

        if (position == null) return;

        position.Description = resource.Description;

        try
        {
            _positionRepository.Update(position);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception) 
        {
            return;
        }
    }

    public async Task Remove(Guid positionId) {
        Position? position = await _positionRepository.GetByIdAsync(positionId);

        if (position == null) return;

        try
        {
            _positionRepository.Remove(position);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception) 
        {
            return;
        }
    }
}
