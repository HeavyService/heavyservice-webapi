using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Instruments;
using HeavyService.Domain.Entities.Instruments;
using HeavyService.Persistance.Dtos.Instruments;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.Instruments;
using Microsoft.Extensions.Caching.Memory;

namespace HeavyService.Service.Services.Instruments;

public class InstrumentService : IInstrumentService
{
    private readonly IInstrumentRepository _repository;
    private readonly IFileService _fileServise;
    private readonly IMemoryCache _memoryCache;
    private const int second = 30;

    public InstrumentService(IInstrumentRepository instrumentrepository,
        IFileService fIleService,
        IMemoryCache memorycache)
    {
        this._repository = instrumentrepository;
        this._fileServise = fIleService;
        this._memoryCache = memorycache;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(InstrumentCreateDto dto)
    {
        string imagepaht = await _fileServise.UploadImageAsync(dto.ImagePath);

        Instrument instrument = new Instrument()
        {
            ImagePath = imagepaht,
            Name = dto.Name,
            Description = dto.Description,
            PricePerDay = dto.PricePerDay,
            Region = dto.Region,
            District = dto.District,
            Address = dto.Address,
            Status = dto.Status,
            PhoneNumber = dto.PhoneNumber,
            UserId = dto.UserId
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
    public async Task<Instrument> GetByIdAsync(long instrumentId)
    {
        if (_memoryCache.TryGetValue(instrumentId, out Instrument cacheinstrument))
        {
            return cacheinstrument;
        }
        else
        {
            var instrument = await _repository.GetByIdAsync(instrumentId);
            if (instrument is null) throw new InstrumentNotFoundExeption();
            _memoryCache.Set(instrumentId, instrument, TimeSpan.FromSeconds(second));
            return instrument;
        }
    }
    public async Task<bool> UpdateAsync(long instrumentId, InstrumentUpdateDto dto)
    {
        var instrument = await _repository.GetByIdAsync(instrumentId);
        if (instrument is null) throw new InstrumentNotFoundExeption();
        instrument.Description = dto.Description;
        instrument.Region = dto.Region;
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
    public async Task<Instrument> GetAllAsync(Paginationparams @params)
    {
        var instrument = await _repository.GetAllAsync(@params);
        return instrument;
    }
}