using CarPool.Domain;
using CarPool.Models;
using CarPool.Repository;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarPool.Controllers
{

    public class BasedApiController : ApiController
    {
        private AuthRepository _repo = null;
        private CarPoolDbContext _newCtx;        

        public IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        public BasedApiController()
        {
            _repo = new AuthRepository();
            _newCtx = new CarPoolDbContext();
            
        }

        public async Task<UserModel> GetUserId(string userName)
        {
            return await Task.Run(() =>
            {
                var user =  _newCtx.AspNetUsers.Where(x => x.Email == userName).FirstOrDefault();

                UserModel model = new UserModel();
                model.UserId = user.Id;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;

                return model;
            });
        }
    }
}
