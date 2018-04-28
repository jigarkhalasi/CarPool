using CarPool.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarPool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarPool.Repository
{
    public class RegisterGroupRepository
    {
        private CarPoolDbContext _context;

        public RegisterGroupRepository()
        {
            _context = new CarPoolDbContext();
        }

        public async Task<bool> AddRegisterGroup(tblRegistedGroup model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.IsDeleted = false;
            model.IsActivate = false;
            _context.tblRegistedGroups.Add(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRegisterGroup(tblRegistedGroup model)
        {
            var data = await _context.tblRegistedGroups.FindAsync(model.RGroupId);


            data.RGType = model.RGType;
            data.RGName = model.RGName;
            data.StartFrom = model.StartFrom;
            data.EndFrom = model.EndFrom;
            data.RGDesc = model.RGDesc;
            data.RGImagePath = model.RGImagePath;
            data.IsAutoRegister = model.IsAutoRegister;
            data.RGLink = model.RGLink;
            data.IsRanking = 1;//default set
            data.City = model.City;
            data.Country = model.Country;
            data.UpdatedBy = model.UpdatedBy;            
            data.IsDeleted = false;
            data.GroupAdmin = model.GroupAdmin;
            data.UpdatedDate = DateTime.UtcNow;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<tblRegistedGroup> RegisterGroupById(int RGroupId)
        {
            return await _context.tblRegistedGroups.FindAsync(RGroupId);
        }

        public async Task<IEnumerable<tblRegistedGroup>> GetAllRegisterGroup()
        {
            return await Task.Run(() =>
            {
                return _context.tblRegistedGroups.Where(x => x.IsDeleted == false).ToList();
            });
        }

        public async Task<bool> DeleteRegisterGroupById(int RGroupId)
        {
            var data = await _context.tblRegistedGroups.FindAsync(RGroupId);
            data.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}