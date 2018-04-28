using CarPool.Domain;
using CarPool.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace CarPool.Controllers
{
    [RoutePrefix("api/registergroup")]
    public class RegisterGroupController : BasedApiController
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";

        private RegisterGroupRepository registerGroupRepo { get; set; }
        public RegisterGroupController()
        {
            registerGroupRepo = new RegisterGroupRepository();
        }

        [HttpGet]
        //[Authorize]
        [Route("getallRegistergroup")]
        public async Task<IHttpActionResult> GetAllRegisterGroup()
        {
           // var user = await GetUserId(Authentication.User.Identity.Name);
            //if (user != null)
            //{
                var RGData = await registerGroupRepo.GetAllRegisterGroup();
                return Ok(RGData);
            //}
            //return Ok(false);
        }

        [HttpGet]
        [Authorize]
        [Route("getRegistergroupById")]
        public async Task<IHttpActionResult> GetRegisterGroupById(int rGroupId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (user != null)
            {
                var RGData = await registerGroupRepo.RegisterGroupById(rGroupId);
                return Ok(RGData);
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("addRegistergroup")]
        public async Task<IHttpActionResult> AddRegisterGroup(tblRegistedGroup model)
        {
            try
            {
                var user = await GetUserId(Authentication.User.Identity.Name);
                if (model != null && user != null)
                {
                    model.CreatedBy = user.UserId;
                    return Ok(await registerGroupRepo.AddRegisterGroup(model));
                }
                return Ok(false);
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
                
            }
            
        }

        [HttpPost]
        [Authorize]
        [Route("updateRegistergroup")]
        public async Task<IHttpActionResult> UpdateRegisterGroup(tblRegistedGroup model)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (model != null && user != null && model.RGroupId > 0)
            {
                model.UpdatedBy = user.UserId;
                return Ok(await registerGroupRepo.UpdateRegisterGroup(model));
            }
            return Ok(false);
        }

        [HttpPost]
        [Authorize]
        [Route("deleteRegistergroup")]
        public async Task<IHttpActionResult> DeleteRegisterGroup(int rGroupId)
        {
            var user = await GetUserId(Authentication.User.Identity.Name);
            if (rGroupId != 0 && user != null)
            {
                return Ok(await registerGroupRepo.DeleteRegisterGroupById(rGroupId));
            }
            return Ok(false);
        }


        [Route("uploadGroupIcon")]
        [HttpPost]
        public HttpResponseMessage UploadGroupIcon()
        {
           
                var httpRequest = HttpContext.Current.Request;
                string result = string.Empty;

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 20; //Size = 20 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            throw new Exception("Please upload image of type .jpg, .jpeg, .gif, .png.");
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            throw new Exception("Please upload a file upto 1 mb.");
                        }
                        else
                        {
                            var fileName = Guid.NewGuid().ToString() + extension;
                            var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName);
                            postedFile.SaveAs(filePath);

                            result = "/Content/Images/" + fileName;

                            return Request.CreateResponse(HttpStatusCode.Created, result);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Please upload a image"); 
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Please upload a image"); 
        }

    }
}
