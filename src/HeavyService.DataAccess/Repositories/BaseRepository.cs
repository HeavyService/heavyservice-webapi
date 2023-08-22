using Npgsql;

namespace HeavyService.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        //this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=HeavyService-db; User Id=postgres; " +
        //    "Password=1111;");
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=Heavyservice; User Id=postgres; " +
            "Password=abdurahim2005;");
    }
}