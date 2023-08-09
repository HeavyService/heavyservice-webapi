﻿using Dapper;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.InstrumentComments;
using HeavyService.DataAccess.ViewModels;

namespace HeavyService.DataAccess.Repositories.InstrumentComment;

public class InstrumentCommentRepository : BaseRepository, IInstrumentComment
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM instrument_comments;";

            return await _connection.QuerySingleAsync<long>(query);
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
    public async Task<int> CreateAsync(Domain.Entities.InstrumentsComments.InstrumentComment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.instrument_comments(user_id, instrument_id, comment, created_at, updated_at, is_edited, reply_id)" +
                "VALUES (@UserId, @InstrumentId, @Comment, @CreatedAt, @UpdatedAt, @IsEdited,  @ReplyId);";
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
            string query = "DELETE FROM public.instrument_comments WHERE id=@Id;";
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

    public async Task<IList<InstrumentCommentViewModel>> GetAllAsync(Paginationparams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM admins order by id desc " +
                $"offset {0} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<InstrumentCommentViewModel>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<InstrumentCommentViewModel>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<InstrumentCommentViewModel> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM instrument_comments where id = @Id";
            var result = await _connection.QuerySingleAsync<InstrumentCommentViewModel>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Domain.Entities.InstrumentsComments.InstrumentComment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.instrument_comments" +
                "SET user_id = @UserId, instrument_id = @InstrumentId, comment = @Comment," +
                " created_at = @CreatedAt, updated_at = @UpdatedAt, is_edited = @IsEdited, reply_id = @ReplyId" +
                "WHERE id=@Id;";
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
}