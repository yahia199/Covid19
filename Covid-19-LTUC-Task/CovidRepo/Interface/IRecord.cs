using CovidEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRepo.Interface
{
    public interface IRecord
    {
        Task<Record> CreateCategory(Category Category);

        Task<List<Category>> GetCategories();

        Task<Category> GetCategory(int Id);

        Task<Category> UpdateCategory(int Id, Category Category);

        Task DeleteCategory(int Id);
    }
}
