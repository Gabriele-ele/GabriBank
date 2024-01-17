using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;
        
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<List<User>> GetAll() 
        {
            return (Task<List<User>>)_connection.Query<User>("SELECT id, name, address FROM users");
        }

        public async Task<User> GetById(int id)
        {
            string sql = $"SELECT id, name, address FROM users WHERE id = @id";
            var queryArguments = new
            {
                id = id,
            };
            return await _connection.QuerySingleAsync<User>(sql, queryArguments);
        }
    }
}
