using HeavyService.Application.Exeptions.Files;
using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Exeptions.Transports;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Transports;
using HeavyService.DataAccess.Repositories.Transports;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Transports;
using HeavyService.Persistance.Dtos.Transports;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.Transports;
using HeavyService.Service.Interfaces.Users;

namespace HeavyService.Service.Services.Transports;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _repository;
    private readonly IFileService _fileServise;
    private readonly IPaginator _paginator;
    private readonly IIdentityService _service;

    public TransportService(ITransportRepository repository,
        IFileService fileServise, IPaginator paginator,
        IIdentityService identity)
    {
        this._repository = repository;
        this._fileServise = fileServise;
        this._paginator = paginator;
        this._service = identity;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(TransportCreateDto dto)
    {
        string imagepath = await _fileServise.UploadImageAsync(dto.ImagePath);
        Transport transport = new Transport()
        {
            ImagePath = imagepath,
            Description = dto.Description,
            PricePerHours = dto.PricePerHours,
            Name = dto.Name,
            District = dto.District,
            Address = dto.Address,
            Region = dto.Region,
            Status = dto.Status,
            UserId = _service.UserId,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(transport);
       
        return result > 0;
    }
    public async Task<bool> DeleteAsync(long transportId)
    {
        var transport = await _repository.GetByIdAsync(transportId);
        if (transport is null) throw new TransportNotFoundExeption();

        var dbResult = await _repository.DeleteAsync(transportId);
        
        var result = await _fileServise.DeleteImageAsync(transport.ImagePath);
        if (result == false) throw new FilesNotFoundExeption();
       
        return dbResult > 0;
    }
    public async Task<IList<TransportViewModel>> GetAllAsync(Paginationparams @params)
    {
        var transport = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return transport;
    }
    public async Task<TransportViewModel> GetByIdAsync(long transportId)
    {
        var transport = await _repository.GetByIdAsync(transportId);
        if (transport is null) throw new TransportNotFoundExeption();
        
        return transport;
    }

    public async Task<IList<TransportViewModel>> SearchAsync(string search, Paginationparams @params)
    {
        var transport = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return transport;
    }

    public async Task<bool> UpdateAsync(long transportId, TransportUpdateDto dto)
    {
        var transport = await _repository.GetIdAsync(transportId);
        if (transport is null) throw new InstrumentNotFoundExeption();
        transport.Description = dto.Description;
        transport.PricePerHours = dto.PricePerHours;
        transport.Region = dto.Region;
        transport.UserId = _service.UserId;
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