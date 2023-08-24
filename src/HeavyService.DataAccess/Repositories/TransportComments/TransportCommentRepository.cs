using Dapper;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.TransportComments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.TransportComments;

namespace HeavyService.DataAccess.Repositories.TransportComments;

public class TransportCommentRepository : BaseRepository, ITransportCommentRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from transport_comments";
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

    public async Task<int> CreateAsync(TransportComment entity)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "INSERT INTO public.transport_comments( " +
                "user_id, transport_id, comment, created_at, updated_at, is_edited, replay_id) " +
                    "VALUES (@UserId, @TransportId, @Comment, @CreatedAt, @UpdatedAt, @IsEdited, @ReplayId);";
            
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
            string query = $"DELETE FROM transport_comments WHERE id=@Id";
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

    public async Task<IList<TransportCommentViewmodel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT transport_comments.id, users.first_name, users.last_name, transports.name," +
                "transport_comments.comment, transport_comments.created_at, transport_comments.updated_at FROM " +
                    "transport_comments join users on transport_comments.user_id = users.id join transports on " +
                        "transport_comments.transport_id = transports.id ORDER BY transport_comments.id DESC " +
                            $"offset {@params.SkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<TransportCommentViewmodel>(query)).ToList();
            
            return result;
        }
        catch
        {
            return new List<TransportCommentViewmodel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<TransportCommentViewmodel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT transport_comments.id, users.first_name, users.last_name, transports.name," +
                "transport_comments.comment, transport_comments.created_ad, transport_comments.updated_at FROM " +
                    "transport_comments join users on transport_comments.user_id = users.id join transports on " +
                        "transport_comments.transport_id = transports.id where transport_comments.id = @Id;"; 
            
            var result = await _connection.QuerySingleAsync<TransportCommentViewmodel>(query, new { Id = id });
           
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

    public async Task<TransportComment> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM transport_comments where id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync<TransportComment>(query, new { Id = id });

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

    public async Task<int> UpdateAsync(long id, TransportComment entity)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "UPDATE public.transport_comments SET  user_id=@UserId, transport_id=@TransportId, " +
                "comment=@Comment, created_at=@CreatedAt, updated_at=@UpdatedAt, is_edited=@IsEdited, replay_id=@ReplayId " +
                    $"WHERE id={id};";
            
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