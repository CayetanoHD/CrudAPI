using AutoMapper;
using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Application.Exeptions;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using MediatR;


namespace CrudAPI.Core.Application.Feature.Queries
{
    public class UserToDoGetByIdQuery : IRequest<UserToDoResponse>
    {
        public int Id { get; set; }
    }

    public class GetProvincesByIdQueryHandler
        : IRequestHandler<UserToDoGetByIdQuery, UserToDoResponse>
    {
        private readonly IUserToDoRepository _userToDoRepository;
        private readonly IMapper _mapper;

        public GetProvincesByIdQueryHandler(IUserToDoRepository provinces, IMapper mapper)
        {
            _userToDoRepository = provinces;
            _mapper = mapper;
        }

        public async Task<UserToDoResponse> Handle(
            UserToDoGetByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var response = await GetProvincesById(request.Id);
            return response;
        }

        private async Task<UserToDoResponse> GetProvincesById(int id)
        {
            var toDosList = await _userToDoRepository.GetAllAsync();
            var userToDo = toDosList.FirstOrDefault(u => u.Id == id);

            if (userToDo == null)
            {
                throw new NotFoundException("No existen tareas con este Id");
            }

            return _mapper.Map<UserToDoResponse>(userToDo);
        }
    }
}
