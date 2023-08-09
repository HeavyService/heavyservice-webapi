using Dapper;
using HeavyService.DataAccess.Interfaces.Roles;
using HeavyService.Domain.Entities.Roles;

namespace HeavyService.DataAccess.Repositories.Roles;

public class RoleRepository : BaseRepository, IRoleRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from roles";
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
    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM roles WHERE id=@Id";
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
    public async Task<Role?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM roles where id = @Id";
            var result = await _connection.QuerySingleAsync<Role>(query, new { Id = id });
            
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
    public async Task<int> UpdateAsync(long id, Role entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.roles SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                "WHERE id = @Id;";
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
    public async Task<int> CreateAsync(Role entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.roles(name, created_at, updated_at) " +
                "VALUES (@Name, @CreatedAt, @UpdatedAt);";
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
