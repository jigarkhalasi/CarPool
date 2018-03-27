using CarPool.Domain;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarPool.Repository
{
    public class UserRepository
    {
         private CarPoolDbContext _context;

         public UserRepository()
        {
            _context = new CarPoolDbContext();
        }

         public async Task<bool> UpdateUser(UserModel userModel)
        {
            if (userModel != null)
            {
                var userDataModel = _context.AspNetUsers.Where(u => u.Id == userModel.UserId).First();

                userDataModel.Id = userModel.UserId;
                userDataModel.FirstName = userModel.FirstName;
                userDataModel.LastName = userModel.LastName;
                userDataModel.Email = userModel.Email;
                //userDataModel.Address1 = userModel.Address1;
                //userDataModel.Address2 = userModel.Address2;
                //userDataModel.Street = userModel.Street;                
                //userDataModel.City = userModel.City;
                //userDataModel.State = userModel.State;
                //userDataModel.ZipCode = userModel.ZipCode;
                //userDataModel.Country = "India";
                userDataModel.UpdatedBy = userModel.UserId;
                userDataModel.UpdatedDate = DateTime.Now;

            }            

            return await _context.SaveChangesAsync() > 0;
        }
    }
}