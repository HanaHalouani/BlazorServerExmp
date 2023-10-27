namespace DataAccesslibrairy;

public interface ISqlDataAccess
{
    Task<List<T>> LoadData<T, U>(string sql, U parameters);
    Task SaveData<T, U>(string sql, U parameters);
}