using Dapper;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Instruments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Instruments;

namespace HeavyService.DataAccess.Repositories.Instruments;

public class InstrumentRepository : BaseRepository, IInstrumentRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from instruments";
            var result = await _connection.QuerySingleAsync<long>(query);
           
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Instrument entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.instruments(name, description, image_path, price_per_day, region, " +
                "district, address, status, created_at, updated_at, user_id, phone_number) " +
                "VALUES (@Name, @Description, @ImagePath, @PricePerDay, @Region, @District, @Address, @Status, " +
                "@CreatedAt, @UpdatedAt, @UserId, @PhoneNumber);";
            var result = await _connection.ExecuteAsync(query, entity);
           
            return result;
        }
        catch 
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM instruments WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            
            return result;

        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<InstrumentViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM instruments order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<InstrumentViewModel>(query)).ToList();
           
            return result;
        }
        catch
        {
            return new List<InstrumentViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<InstrumentViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM instruments where id = @Id";
            var result = await _connection.QuerySingleAsync<InstrumentViewModel>(query, new { Id = id });
            
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemsCount, IList<InstrumentViewModel>)> SearchAsync(string search, Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Instrument entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.instruments SET name=@Name, description=@Description, image_path=@ImagePath, " +
                "price_per_day=@PricePerDay, region=@Region, district=@District, address=@Address, " +
                "status=@Status, created_at=@CreatedAt, updated_at=@UpdatedAt, user_id=@UserId, " +
                "phone_number=@PhoneNumber WHERE id = {id};";
            var result = await _connection.ExecuteAsync(query, entity);
           
            return result;
        }
        catch 
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
