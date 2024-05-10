using AutoMapper;
using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Application.Exeptions;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using CrudAPI.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Feature.Queries
{
    public class GetAllUserToDoQuery : IRequest<IList<UserToDoResponse>>
    {

    }
    public class GetAllUserToDoQueryHandler : IRequestHandler<GetAllUserToDoQuery, IList<UserToDoResponse>>
    {
        private readonly IUserToDoRepository _userToDoRepository;
        private readonly IMapper _mapper;
        public GetAllUserToDoQueryHandler(IUserToDoRepository user, IMapper mapper)
        {
            _userToDoRepository = user;
            _mapper = mapper;   
        }
        public async Task<IList<UserToDoResponse>> Handle(GetAllUserToDoQuery request, CancellationToken cancellationToken)
        {
            var response = await GetAllResponse();

            return response;
        }

        private async Task<List<UserToDoResponse>> GetAllResponse()
        {
            var toDoList = await _userToDoRepository.GetAllAsync();

            if (toDoList.Count == 0 || toDoList == null) { throw new Exception($"No hay Tareas Creadas"); }

            var mapper = _mapper.Map<IList<UserToDoResponse>>(toDoList);

            return (List<UserToDoResponse>)mapper;
        }
    }
}
