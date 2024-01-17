using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();

        public Task<User> GetById(int id);

        //public Task<bool> Update(int id, string name, string address);

        //public Task<bool> Delete(int id);

        //public Task<int> Add(User user);
    }
}
