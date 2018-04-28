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
    [RoutePrefix("api/userGroupRequest")]
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
        public async Task<IHttpActionResult> GetAllUserGroupRequest()
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
        public async Task<IHttpActionResult> GetUserGroupRequestById(int grId)
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
        public async Task<IHttpActionResult> AddUserGroupRequest(tblUserRGDetail model)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (model != null && user != null)
            {
                model.UserID = user.UserId;
                model.CreatedBy = user.UserId;
                model.RGToken = EncodeGenerateToken();
                return Ok(await UserGroupRequestRepo.AddUserGroupRequest(model));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("updateUserGroupRequest")]
        public async Task<IHttpActionResult> UpdateUserGroupRequest(tblUserRGDetail model)
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
        public async Task<IHttpActionResult> DeleteUserGroupRequest(int grId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (grId != 0 && user != null)
            {
                return Ok(await UserGroupRequestRepo.DeleteUserGroupRequestById(grId));
            }
            return Ok(false);
        }

        public string EncodeGenerateToken() {
            string str = string.Empty;
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            str = Convert.ToBase64String(time.Concat(key).ToArray());
            return str;
        }

        public bool DecodeGenerateToken(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                return false;
            }

            return true;
        }
    }
}
