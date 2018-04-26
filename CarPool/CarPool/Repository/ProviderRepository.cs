using CarPool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarPool.Repository
{
    public class ProviderRepository
    {
        private CarPoolDbContext _context;

        public ProviderRepository()
        {
            _context = new CarPoolDbContext();
        }

        public async Task<bool> AddProvider(tblProviderUser providerModel)
        {
            providerModel.CreatedDate = DateTime.UtcNow;
            _context.tblProviderUsers.Add(providerModel);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProvider(tblProviderUser providerModel)
        {
            var data = await _context.tblProviderUsers.FindAsync(providerModel.ProviderId);

            data.RegistrationNo = providerModel.RegistrationNo;
            data.StartPoint = providerModel.StartPoint;
            data.EndPoint = providerModel.EndPoint;
            data.TotalYearExp = providerModel.TotalYearExp;
            data.CarModel = providerModel.CarModel;
            data.UpdatedBy = providerModel.UpdatedBy;
            data.UpdatedDate = DateTime.UtcNow;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<tblProviderUser> GetProviderById(int providerId)
        {
           return await _context.tblProviderUsers.FindAsync(providerId);
        }

        public async Task<IEnumerable<tblProviderUser>> GetAllProvider()
        {
            return await Task.Run(() =>
            {
                return _context.tblProviderUsers.ToList();
            });
        }

        public async Task<bool> DeleteProviderById(int providerId)
        {
            var data = await _context.tblProviderUsers.FindAsync(providerId);
            data.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
        
    }
}