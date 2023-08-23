using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Instruments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Instruments;
using HeavyService.Persistance.Dtos.Instruments;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.Instruments;
using HeavyService.Service.Interfaces.Users;

namespace HeavyService.Service.Services.Instruments;

public class InstrumentService : IInstrumentService
{
    private readonly IInstrumentRepository _repository;
    private readonly IFileService _fileServise;
    private readonly IPaginator _paginator;
    private readonly IIdentityService _service;

    public InstrumentService(IInstrumentRepository instrumentrepository,
        IFileService fIleService, IPaginator paginator,
        IIdentityService identity)
    public InstrumentService(IInstrumentRepository instrumentrepository,
        IFileService fIleService, IPaginator paginator, IIdentityService identityservice)
    {
        this._repository = instrumentrepository;
        this._fileServise = fIleService;
        this._paginator = paginator;
        this._service = identity;
        this._service = identityservice;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(InstrumentCreateDto dto)
    {
        string imagepath = await _fileServise.UploadImageAsync(dto.ImagePath);
        Instrument instrument = new Instrument()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            Description = dto.Description,
            PricePerDay = dto.PricePerDay,
            Region = dto.Region,
            District = dto.District,
            Address = dto.Address,
            Status = dto.Status,
            Status = dto.Status, 
            UserId = _service.UserId,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(instrument);
        
        return result > 0;
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var instrument = await _repository.GetByIdAsync(id);
        if (instrument is null) throw new InstrumentNotFoundExeption();

        var result = await _fileServise.DeleteImageAsync(instrument.ImagePath);
        if (result == false) throw new InstrumentNotFoundExeption();

        var dbResult = await _repository.DeleteAsync(id);
        
        return dbResult > 0;
    }
    public async Task<InstrumentViewModel> GetByIdAsync(long instrumentId)
    {
        var instrument = await _repository.GetByIdAsync(instrumentId);
        if (instrument is null) throw new InstrumentNotFoundExeption();
        return instrument;
    }
    public async Task<bool> UpdateAsync(long instrumentId, InstrumentUpdateDto dto)
    {
        var instrument = await _repository.GetIdAsync(instrumentId);
        if (instrument is null) throw new InstrumentNotFoundExeption();
        instrument.Description = dto.Description;
        instrument.PricePerDay = dto.PricePerDay;
        instrument.Region = dto.Region;
        instrument.UserId = _service.UserId;
        instrument.Status = dto.Status;
        instrument.PhoneNumber = dto.PhoneNumber;
        instrument.Address = dto.Address;
        if (dto.ImagePath is not null)
        {
            var deleteResult = await _fileServise.DeleteImageAsync(instrument.ImagePath);
            if (deleteResult is false) throw new FileNotFoundException();
            string newImagePath = await _fileServise.UploadImageAsync(dto.ImagePath);
            instrument.ImagePath = newImagePath;
        }
        instrument.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(instrumentId, instrument);
        
        return dbResult > 0;
    }
    public async Task<IList<InstrumentViewModel>> GetAllAsync(Paginationparams @params)
    {
        var instrument = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return instrument;
    }

    public async Task<IList<InstrumentViewModel>> SearchAsync(string search, Paginationparams @params)
    {
        var result = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return result;
    }
}