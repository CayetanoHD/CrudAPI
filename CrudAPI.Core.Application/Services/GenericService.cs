using AutoMapper;
using CrudAPI.Core.Application.Interfaces.Repositories;
using CrudAPI.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Services
{
    public class GenericServices<DTORequest, DTOResponse, Entity>
    : IGenericService<DTORequest, DTOResponse, Entity>
    where DTORequest : class
    where DTOResponse : class
    where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericServices(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DTORequest> Add(DTORequest vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _repository.AddAsync(entity);
            DTORequest request = _mapper.Map<DTORequest>(entity);
            return request;
        }

        public async Task Delete(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<DTOResponse>> GetAllResponse()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<DTOResponse>>(list);
        }

        public async Task<DTORequest> GetByIdSaveRequest(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            DTORequest request = _mapper.Map<DTORequest>(entity);
            return request;
        }

        public async Task Update(DTORequest vm, int Id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, Id);
        }
    }

}
