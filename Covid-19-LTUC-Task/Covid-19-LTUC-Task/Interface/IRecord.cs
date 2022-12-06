using Covid_19_LTUC_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRepo.Interface
{
    public interface ICountries
    {
        Task<Countries> CreateCountries(Countries Country);

        Task<List<Countries>> GetCountriess();

        Task<Countries> GetCountries(Guid Id);

        Task<Countries> UpdateCountries(Guid Id, Countries Country);

        Task DeleteCountries(Guid Id);
    }
}
