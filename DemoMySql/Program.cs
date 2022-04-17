using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

using var connection = new MySqlConnection
    (Environment.GetEnvironmentVariable("Connection"));

var parameters = new DynamicParameters();
parameters.Add("identifier", 5, DbType.Int32, ParameterDirection.Input);

connection.Execute
    ("DeleteUser",parameters, commandType: CommandType.StoredProcedure);

public record User(int Id, string Name, string Email, string Address);