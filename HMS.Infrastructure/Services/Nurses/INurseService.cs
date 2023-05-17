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
        Task<int> Create(CreateNurseDto dto);
        Task<int> Update(UpdateNurseDto dto);
        Task<int> Delete(int Id);
        Task<UpdateNurseDto> Get(int Id);
        Task<byte[]> ExportToExcel();
    }
}
