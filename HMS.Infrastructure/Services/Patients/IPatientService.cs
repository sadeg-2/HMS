using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services.Patients
{
    public interface IPatientService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreatePatientDto dto);
        Task<int> Update(UpdatePatientDto dto);
        Task<int> Delete(int Id);
        Task<UpdatePatientDto> Get(int Id);
        Task<byte[]> ExportToExcel();
    }
}
