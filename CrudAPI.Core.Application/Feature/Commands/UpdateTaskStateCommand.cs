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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrudAPI.Core.Application.Feature.Commands
{
    public class UpdateTaskStateCommand : IRequest<string>
    {
        [SwaggerParameter(Description = "Id of the task to update")]
        public int Id { get; set; }
    }

    public class UpdateTaskStateCommandHandler : IRequestHandler<UpdateTaskStateCommand, string>
    {
        private readonly IUserToDoRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTaskStateCommandHandler(IUserToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateTaskStateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateTaskState(request.Id, "Finalizada");
                return "Operación exitosa"; // Indica que la operación fue exitosa
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el estado de la tarea: {ex.Message}");
            }
        }
    }

}
