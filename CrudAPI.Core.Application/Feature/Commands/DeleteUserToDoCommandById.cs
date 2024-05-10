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
    public class DeleteUserToDoCommandById : IRequest<int>
    {
        ///<example>Id= 1</example>
        [SwaggerParameter(Description = "Id es requerido")]
        public int Id { get; set; }
    }

    public class DeleteUserToDoCommandByIdHandler : IRequestHandler<DeleteUserToDoCommandById, int>
    {
        private readonly IUserToDoRepository _repository;
        public DeleteUserToDoCommandByIdHandler(IUserToDoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(DeleteUserToDoCommandById command, CancellationToken cancellationToken)
        {
            var saleType = await _repository.GetByIdAsync(command.Id);

            if (saleType == null) { throw new Exception($"Tarea no encongtrada"); }

            await _repository.DeleteAsync(saleType);

            return saleType.Id;
        }
    }
}
