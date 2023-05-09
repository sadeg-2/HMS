using HMS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services.Nurses
{
    public interface  INurseService 
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<string> Create(CreateNurseDto dto);
        Task<string> Update(UpdateNurseDto dto);
        Task<string> Delete(string Id);
        Task<UpdateNurseDto> Get(string Id);
    }
}
