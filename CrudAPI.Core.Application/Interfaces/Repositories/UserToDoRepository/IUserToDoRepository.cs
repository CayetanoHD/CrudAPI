using CrudAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository
{
    public interface IUserToDoRepository : IGenericRepository<UserToDo>
    {
        Task UpdateTaskState(int taskId, string newState);
    }
}
