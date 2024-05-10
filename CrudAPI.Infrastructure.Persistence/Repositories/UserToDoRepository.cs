using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using CrudAPI.Core.Domain.Entities;
using CrudAPI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Infrastructure.Persistence.Repositories
{
    public class UserToDoRepository : GenericRepository<UserToDo>, IUserToDoRepository
    {
        private readonly ApplicationContext _context;

        public UserToDoRepository(ApplicationContext application) : base(application)
        {
            _context = application;
        }

        public async Task UpdateTaskState(int taskId, string newState)
        {
            var task = await _context.userToDo.FindAsync(taskId);

            if (task != null)
            {
                task.Status = newState;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Tarea con ID {taskId} no encontrada.");
            }
        }
    }
}