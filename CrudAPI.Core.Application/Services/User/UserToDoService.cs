using AutoMapper;
using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Application.Interfaces.Repositories;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using CrudAPI.Core.Application.Interfaces.Services.UserToDoService;
using CrudAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Services.User
{
    public class UserToDoService : GenericServices<UserToDoRequest, UserToDoResponse, UserToDo>, IUserTodoService
    {
        private readonly IUserToDoRepository _repository;
        private readonly IMapper _mapper;
        public UserToDoService(IUserToDoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
