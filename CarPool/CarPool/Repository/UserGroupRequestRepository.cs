using CarPool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarPool.Repository
{
    public class UserGroupRequestRepository
    {
        private CarPoolDbContext _context;

        public UserGroupRequestRepository()
        {
            _context = new CarPoolDbContext();
        }

        public async Task<bool> AddUserGroupRequest(tblUserRGDetail model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.IsActivate = false;
            model.IsDeleted = false;
            _context.tblUserRGDetails.Add(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserGroupRequest(tblUserRGDetail model)
        {
            var data = await _context.tblUserRGDetails.FindAsync(model.GRId);

            data.UserID = model.UserID;
            data.RGroupId = model.RGroupId;
            data.JustificationDesc = model.JustificationDesc;
            data.ImagePath = model.ImagePath;
            data.UpdatedBy = model.UpdatedBy;
            data.UpdatedDate = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<tblUserRGDetail> GetUserGroupRequestById(int grId)
        {
            return await _context.tblUserRGDetails.FindAsync(grId);
        }

        public async Task<IEnumerable<tblUserRGDetail>> GetAllUserGroupRequest()
        {
            return await Task.Run(() =>
            {
                return _context.tblUserRGDetails.Where(x=> x.IsDeleted == false).ToList();
            });
        }

        public async Task<bool> DeleteUserGroupRequestById(int grId)
        {
            var data = await _context.tblUserRGDetails.FindAsync(grId);
            data.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}