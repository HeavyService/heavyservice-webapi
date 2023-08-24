using Dapper;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Users;
using HeavyService.DataAccess.Repositories.UserRoles;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Users;

namespace HeavyService.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM users;";
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
    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "INSERT INTO public.users " +
                "(first_name, last_name, email, email_confirmed, password_hash, salt, created_at, updated_at) " +
                    "VALUES (@FirstName, @LastName, @Email, @EmailConfirmed, @PasswordHash, @Salt, " +
                        "@CreatedAt, @UpdatedAt);";

            var result =  await _connection.ExecuteAsync(query, entity);

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
            var role = new UserRoleRepository();
            await role.DeleteAsync(id);
            
            await _connection.OpenAsync();
            
            string query = "DELETE from users WHERE id = @Id";
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
    public async Task<IList<UserViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT * FROM users ORDER BY id DESC " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            
            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE email = @Email;";
            var data = await _connection.QuerySingleOrDefaultAsync<User>(query, new { Email = email });
            
            return data;
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
    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE id = @Id";
            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new { Id = id });

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
    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            
            return data;
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

    public async Task<User?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE id = @Id";
            var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });

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

    public async Task<User?> GetLastIdAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from users order by id desc limit 1";
            var result = await _connection.QuerySingleAsync<User>(query);

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

    public async Task<IList<UserViewModel>> SearchAsync(string search, Paginationparams @params)
    public Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = $"SELECT * FROM users where first_name ilike '%{search}%' or last_name ilike '%{search}%' " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";
            
            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch 
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = $"UPDATE public.users SET first_name=@FirstName, last_name=@LastName, email=@Email, " +
                $"created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = {id};";
            
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