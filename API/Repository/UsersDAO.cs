using API.Models.JWT;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string userName)
        {
            using (MySqlConnection conexao = new MySqlConnection(_configuration.GetConnectionString("ExemploJWT")))
            {
                return conexao.QueryFirstOrDefault<User>(
                    "SELECT UserName, Password " +
                    "FROM Usuarios " +
                    "WHERE UserName = @UserName", new { UserName = userName });
            }
        }
    }
}