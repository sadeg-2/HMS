using HMS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services.Doctors
{
    public interface IDoctorService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateDoctorDto dto);
        Task<int> Update(UpdateDoctorDto dto);
        Task<int> Delete(int Id);
        Task<UpdateDoctorDto> Get(int Id);
    }
}
