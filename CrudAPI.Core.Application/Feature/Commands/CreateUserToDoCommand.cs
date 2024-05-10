using AutoMapper;
using CrudAPI.Core.Application.Interfaces.Repositories.UserToDoRepository;
using CrudAPI.Core.Domain.Entities;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Feature.Commands
{
    public class CreateUserToDoCommand : IRequest<int>
    {
       
        [SwaggerParameter(Description = "TaskName es requerido")]
        public string TaskName { get; set; }

        [SwaggerParameter(Description = "TaskDescription es requerido")]
        public string TaskDescription { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateUserToDoCommand, int>
    {
        private readonly IUserToDoRepository _user;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUserToDoRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<int> Handle(
            CreateUserToDoCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = _mapper.Map<UserToDo>(request);

            var create = await _user.AddAsync(user);


            return create.Id;
        }
    }

}
