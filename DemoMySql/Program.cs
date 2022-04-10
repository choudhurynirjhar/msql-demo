
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

using var connection = new MySqlConnection
    (Environment.GetEnvironmentVariable("Connection"));
var parameters = new DynamicParameters();
parameters.Add("identifier", 2, DbType.Int32, ParameterDirection.Input);
var users = connection.Query<User>
    ("GetUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
Console.WriteLine(string.Join(Environment.NewLine, 
    users.Select(u => $"{u.Name}, {u.Email}, {u.Address}")));


public record User(int Id, string Name, string Email, string Address);