using CarPool.Domain;
using CarPool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarPool.Controllers
{
    public class UserGroupRequestController : BasedApiController
    {
        private UserGroupRequestRepository UserGroupRequestRepo { get; set; }
        public UserGroupRequestController()
        {
            UserGroupRequestRepo = new UserGroupRequestRepository();
        }

        [HttpGet]
        [Authorize]
        [Route("getallUserGroupRequest")]
        public async Task<IHttpActionResult> GetAllProvider()
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (user != null)
            {
                var providerData = await UserGroupRequestRepo.GetAllUserGroupRequest();
                return Ok(providerData);
            }
            return Ok(false);
        }

        [HttpGet]
        [Authorize]
        [Route("getUserGroupRequestById")]
        public async Task<IHttpActionResult> GetproviderById(int grId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (user != null)
            {
                var providerData = await UserGroupRequestRepo.GetUserGroupRequestById(grId);
                return Ok(providerData);
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("addUserGroupRequest")]
        public async Task<IHttpActionResult> AddProvider(tblUserRGDetail model)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (model != null && user != null)
            {
                model.CreatedBy = user.UserId;
                return Ok(await UserGroupRequestRepo.AddUserGroupRequest(model));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("updateUserGroupRequest")]
        public async Task<IHttpActionResult> updateProvider(tblUserRGDetail model)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (model != null && user != null && model.GRId > 0)
            {
                model.UpdatedBy = user.UserId;
                return Ok(await UserGroupRequestRepo.UpdateUserGroupRequest(model));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("deleteUserGroupRequest")]
        public async Task<IHttpActionResult> deleteProvider(int grId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (grId != 0 && user != null)
            {
                return Ok(await UserGroupRequestRepo.DeleteUserGroupRequestById(grId));
            }
            return Ok(false);
        }
    }
}
