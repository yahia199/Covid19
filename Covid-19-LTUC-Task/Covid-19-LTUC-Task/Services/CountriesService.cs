using Covid_19_LTUC_Task.Data;
using Covid_19_LTUC_Task.Models;
using CovidRepo.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_LTUC_Task.Services
{
    public class CountriesService : ICountries
    {

        private MyDbContext _context;

        public CountriesService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Countries> CreateCountries(Countries Countries)
        {
            _context.Entry(Countries).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return Countries;
        }

        public async Task DeleteCountries(Guid Id)
        {
            Countries Countries = await _context.Countries.FindAsync(Id);
            _context.Entry(Countries).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Countries>> GetCountriess()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Countries> GetCountries(Guid Id)
        {
            return await _context.Countries.FindAsync(Id);
        }

        public Task<Countries> UpdateCountries(Guid Id, Countries Countries)
        {
            throw new NotImplementedException();
        }

        //public async Task<Countries> UpdateCountries(Guid Id, Countries Countries)
        //{
        //    Countries UpdatedCountries = new Countries
        //    {
        //        Id = Countries.Id,
        //        CountryName = Countries.CountryName,
        //        TotalConfirmed = Countries.TotalConfirmed,
        //        TotalDeaths = Countries.TotalDeaths,
        //        TotalCases = Countries.TotalCases,
        //        Date = Countries.Date
        //    };
        //    _context.Entry(UpdatedCountries).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return Countries;
        //}
    }
}
