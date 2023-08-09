using Dapper;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.UserRoles;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.UserRoles;

namespace HeavyService.DataAccess.Repositories.UserRoles;

public class UserRoleRepository : BaseRepository, IUserRoleRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from user_roles";
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
            string query = $"DELETE FROM user_roles WHERE id=@Id";
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
    public async Task<IList<UserRoleViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM user_roles order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<UserRoleViewModel>(query)).ToList();
            
            return result;
        }
        catch
        {
            return new List<UserRoleViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<UserRoleViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM user_roles where id = @Id";
            var result = await _connection.QuerySingleAsync<UserRoleViewModel>(query, new { Id = id });
            
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
    public async Task<int> UpdateAsync(long id, UserRole entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.user_roles SET role_id=@RoleId, user_id=@UserId, created_at=@CreatedAt, " +
                $"updated_at=@UpdatedAt WHERE id = {id};";
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
    public async Task<int> CreateAsync(UserRole entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.user_roles(role_id, user_id, created_at, updated_at) " +
                "VALUES (@RoleId, @UserId, @CreatedAt, @UpdatedAt);";
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
