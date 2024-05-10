using AutoMapper;
using CrudAPI.Core.Application.DTOS.UserTodo;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Feature.Commands
{
    public class UpdateUserToDoCommand : IRequest<UserToDoResponse>
    {
        [SwaggerParameter(Description = "Id is requiered")]
        public int Id { get; set; }

       [SwaggerParameter(Description = "TaskName is requiered")]
       public string TaskName { get; set; }

       [SwaggerParameter(Description = "Description of Sale Type to Update")]
       public string TaskDescription { get; set; }
    }

    public class UpdateUserToDoCommandHandler : IRequestHandler<UpdateUserToDoCommand, UserToDoResponse>
    {
        private readonly IUserToDoRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserToDoCommandHandler(IUserToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserToDoResponse> Handle(UpdateUserToDoCommand command, CancellationToken cancellationToken)
        {
            var toDo = await _repository.GetByIdAsync(command.Id);

            if (toDo == null)
            {
                throw new Exception($"Tarea no encontrada ");
            }

            // Mapea el comando UpdateUserToDoCommand a la entidad UserToDo
            _mapper.Map(command, toDo);

            await _repository.UpdateAsync(toDo, toDo.Id);

            var response = _mapper.Map<UserToDoResponse>(toDo);

            return response;

        }
    }
}
