using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Interfaces.Services.UserToDoService
{
    public interface IUserTodoService : IGenericService<UserToDoRequest, UserToDoResponse, UserToDo>
    {
    }
}
