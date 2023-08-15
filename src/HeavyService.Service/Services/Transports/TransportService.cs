using HeavyService.Application.Exeptions.Files;
using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Exeptions.Transports;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Transports;
using HeavyService.DataAccess.Repositories.Transports;
using HeavyService.Domain.Entities.Transports;
using HeavyService.Persistance.Dtos.Transports;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.Transports;
using Microsoft.Extensions.Caching.Memory;

namespace HeavyService.Service.Services.Transports;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _repository;
    private readonly IFileService _fileServise;
    private readonly IMemoryCache _memoryCache;
    private const int second = 30;

    public TransportService(TransportRepository repository,
        IFileService fileServise,
        IMemoryCache memorycache)
    {
        this._repository = repository;
        this._fileServise = fileServise;
        this._memoryCache = memorycache;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(TransportCreateDto dto)
    {
        string imagepaht = await _fileServise.UploadImageAsync(dto.ImagePath);
        Transport transport = new Transport()
        {
            ImagePath = imagepaht,
            Description = dto.Description,
            PricePerHours = dto.PricePerHours,
            Name = dto.Name,
            District = dto.District,
            Address = dto.Address,
            Region = dto.Region,
            Status = dto.Status,
            PhoneNumber = dto.PhoneNumber,
            UserId = dto.UserId,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(transport);
        return result > 0;
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var transport = await _repository.GetByIdAsync(id);
        if (transport is null) throw new TransportNotFoundExeption();

        var result = await _fileServise.DeleteImageAsync(transport.ImagePath);
        if (result == false) throw new FilesNotFoundExeption();

        var dbResult = await _repository.DeleteAsync(id);
        return dbResult > 0;
    }
    public async Task<Transport> GetAllAsync(Paginationparams @params)
    {
        var transport = await _repository.GetAllAsync(@params);
        return transport;
    }
    public async Task<Transport> GetByIdAsync(long id)
    {
        if (_memoryCache.TryGetValue(id, out Transport cachetransport))
        {
            return cachetransport;
        }
        else
        {
            var transport = await _repository.GetByIdAsync(id);
            if (transport is null) throw new TransportNotFoundExeption();
            _memoryCache.Set(id, transport, TimeSpan.FromSeconds(second));
            return transport;
        }
    }
    public async Task<bool> UpdateAsync(long transportId, TransportUpdateDto dto)
    {
        var transport = await _repository.GetByIdAsync(transportId);
        if (transport is null) throw new InstrumentNotFoundExeption();
        transport.Description = dto.Description;
        transport.Region = dto.Region;
        transport.Status = dto.Status;
        transport.PhoneNumber = dto.PhoneNumber;
        transport.Address = dto.Address;
        if (dto.ImagePath is not null)
        {
            var deleteResult = await _fileServise.DeleteImageAsync(transport.ImagePath);
            if (deleteResult is false) throw new FileNotFoundException();
            string newImagePath = await _fileServise.UploadImageAsync(dto.ImagePath);
            transport.ImagePath = newImagePath;
        }
        transport.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(transportId, transport);
        return dbResult > 0;
    }
}