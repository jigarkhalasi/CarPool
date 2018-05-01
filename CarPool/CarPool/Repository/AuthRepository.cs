using CarPool.Domain;
using CarPool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarPool.Repository
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private CarPoolDbContext _newCtx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _newCtx = new CarPoolDbContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Email,
                Email = userModel.Email
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {

                //Assign Role to user Here      
                await _userManager.AddToRoleAsync(user.Id, userModel.UserRole);

                try
                {
                    //add the register model faculty
                    var userData = _newCtx.AspNetUsers.Where(x => x.Email == userModel.Email).FirstOrDefault();
                    userData.FirstName = userModel.FirstName;
                    userData.LastName = userModel.LastName;

                    await _newCtx.SaveChangesAsync(); 
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                

                //send the email
                //var res = MailService.SendMail(userModel.Email, ApplicationConstant.EmailType.Registration, "data", "data", "data");
            }
           

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            var userDetails = _newCtx.AspNetUsers.Find(model.UserId);

            if (userDetails != null)
            {

                var currentUser = await _userManager.FindByIdAsync(userDetails.Id);

                if (currentUser != null)
                {
                    var result = await _userManager.ChangePasswordAsync(currentUser.Id, model.OldPassword, model.NewPassword);
                }

            }
            return true;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}