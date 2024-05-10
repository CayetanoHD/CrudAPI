using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Interfaces.Services
{
    public interface IGenericService<DTORequest, DTOResponse, Entity>
          where DTORequest : class where DTOResponse : class where Entity : class
    {
        Task Update(DTORequest vm, int Id);

        Task<DTORequest> Add(DTORequest vm);

        Task Delete(int id);

        Task<DTORequest> GetByIdSaveRequest(int id);

        Task<List<DTOResponse>> GetAllResponse();

    }
}
