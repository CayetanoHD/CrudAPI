using AutoMapper;
using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Feature.Queries
{
    public  class GetAllUserTodoEndQuery : IRequest<IList<UserToDoResponse>>
    {
    }
    public class GetAllUserTodoPendingQueryHandler : IRequestHandler<GetAllUserTodoEndQuery, IList<UserToDoResponse>>
    {
        private readonly IUserToDoRepository _userToDoRepository;
        private readonly IMapper _mapper;

        public GetAllUserTodoPendingQueryHandler(IUserToDoRepository user, IMapper mapper)
        {
            _userToDoRepository = user;
            _mapper = mapper;
        }
        public async Task<IList<UserToDoResponse>> Handle(GetAllUserTodoEndQuery request, CancellationToken cancellationToken)
        {
            var response = await GetAllResponse();

            return response;
        }

        private async Task<List<UserToDoResponse>> GetAllResponse()
        {
            var toDoList = await _userToDoRepository.GetAllAsync();

            if (toDoList.Count == 0 || toDoList == null) { throw new Exception($"No hay Tareas Creadas"); }

            // Filtrar las tareas con estado 'pendiente'
            var pendingTasks = toDoList.Where(task => task.Status == "Finalizada").ToList();

            // Mapear las tareas filtradas a UserToDoResponse
            var mapper = _mapper.Map<IList<UserToDoResponse>>(pendingTasks);

            return (List<UserToDoResponse>)mapper;
        }
    }

}
