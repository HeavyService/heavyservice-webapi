using Dapper;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Transports;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Transports;

namespace HeavyService.DataAccess.Repositories.Transports;
public class TransportRepository : BaseRepository, ITransportRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from transports";
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

    public async Task<int> CreateAsync(Transport entity)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "INSERT INTO public.transports(user_id, name, description, image_path, price_per_hours, " +
                "region, district, address, status, created_at, updated_at, phone_number) " +
                    "VALUES (@UserId, @Name, @Description, @ImagePath, @PricePerHours, @Region, @District, " +
                        "@Address, @Status, @CreatedAt, @UpdatedAt, @PhoneNumber);";
            
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
            string query = $"DELETE FROM transports WHERE id=@Id";
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

    public async Task<IList<TransportViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select users.first_name,users.last_name, " +
                $"transports.name,transports.image_path," +
                $"transports.price_per_hours,transports.district," +
                $"transports.region,transports.address,transports.phone_number," +
                $"transports.description from transports " +
                $"join users on transports.user_id = users.id order by transports.id desc " +
                $"offset 0 limit 30";
            
            var result = (await _connection.QueryAsync<TransportViewModel>(query)).ToList();
            
            return result;
        }
        catch
        {
            return new List<TransportViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<TransportViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select users.first_name,users.last_name," +
                $"transports.name,transports.image_path," +
                $"transports.price_per_hours,transports.district," +
                $"transports.region,transports.address,transports.phone_number," +
                $"transports.description from transports " +
                $"join users on transports.user_id = users.id " +
                $"where transports.id = @Id";
            var result = await _connection.QuerySingleAsync<TransportViewModel>(query, new { Id = id });
            
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

    public async Task<Transport?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM transports where id = @Id";
            var result = await _connection.QuerySingleAsync<Transport>(query, new { Id = id });

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

    public Task<(int ItemsCount, IList<TransportViewModel>)> SearchAsync(string search, Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Transport entity)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "UPDATE public.transports SET user_id=@UserId, name= @Name, description=@Description, " +
                "image_path= @ImagePath, price_per_hours=@PricePerHours, region=@Region, " +
                    "district=@District, address=@Address, status= @Status, created_at=@CreatedAt, " +
                        "updated_at=@UpdatedAt, phone_number=@PhoneNumber WHERE id = {id};";
            
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