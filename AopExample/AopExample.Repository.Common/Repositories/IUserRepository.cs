using AopExample.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.Repository.Common.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync();

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<User>> FindAsync(string searchTerm, int page, int rpp);

        Task<User> GetAsync(Guid id);

        Task<int> InsertAsync(User newUser);

        Task<int> UpdateAsync(User user);
    }
}