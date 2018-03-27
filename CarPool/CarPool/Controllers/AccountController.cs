using CarPool.Helper;
using CarPool.Models;
using CarPool.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarPool.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : BasedApiController
    {
        private AuthRepository _repo = null;

        private UserRepository _userRepo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
            _userRepo = new UserRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }


        // POST api/Account/UpdateUser
        [HttpPost]
        [Authorize]
        [Route("updateUser")]
        public async Task<IHttpActionResult> UpdateUser(UserModel userModel)
        {
            if (userModel != null)
            {
                return Ok(await _userRepo.UpdateUser(userModel));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("changePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordModel userModel)
        {
            if (userModel != null)
            {
                return Ok(await _repo.ChangePassword(userModel));
            }
            return Ok(false);
        }

        [HttpPost]
        [Route("forgotPass")]
        public async Task<IHttpActionResult> ForgotPassword(string emailId)
        {
            var user = await GetUserId(emailId);
            if (user != null)
            {
                var res = MailService.SendMail(emailId, ApplicationConstant.EmailType.ForgotPassword, "data", "data", "data");
                return Ok(true);
            }
            return Ok(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
