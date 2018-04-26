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
    [RoutePrefix("api/provider")]
    public class ProviderController : BasedApiController
    {
        private ProviderRepository providerRepo { get; set; }
        public ProviderController()
        {
            providerRepo = new ProviderRepository();
        }

        [HttpGet]
        [Authorize]
        [Route("getallprovider")]
        public async Task<IHttpActionResult> GetAllProvider()
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (user != null)
            {
                var providerData = await providerRepo.GetAllProvider();
                return Ok(providerData);
            }
            return Ok(false);
        }

        [HttpGet]
        [Authorize]
        [Route("getproviderById")]
        public async Task<IHttpActionResult> GetproviderById(int providerId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (user != null)
            {
                var providerData = await providerRepo.GetProviderById(providerId);
                return Ok(providerData);
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("addProvider")]
        public async Task<IHttpActionResult> AddProvider(tblProviderUser model)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (model != null && user != null)
            {
                model.CreatedBy = user.UserId;
                return Ok(await providerRepo.AddProvider(model));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("updateProvider")]
        public async Task<IHttpActionResult> updateProvider(tblProviderUser model)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (model != null && user != null && model.ProviderId > 0)
            {
                model.UpdatedBy = user.UserId;
                return Ok(await providerRepo.UpdateProvider(model));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("deleteProvider")]
        public async Task<IHttpActionResult> deleteProvider(int providerId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (providerId != 0 && user != null)
            {
                return Ok(await providerRepo.DeleteProviderById(providerId));
            }
            return Ok(false);
        }
    }
}
