using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFileSystem.Models;
namespace WebApiFileSystem.Controllers
{
    [RoutePrefix("api/files")]
    public class FilesController : ApiController
    {
        [Route("drives")]
        public IHttpActionResult GetDrives()
        {
            var drives = FileSearch.GetDrives();

            return Ok(drives);
        }
        [Route("topdir")]
        public IHttpActionResult GetTopDirectory(string rootDir)
        {
            string root = Uri.UnescapeDataString(rootDir);
            var content = FileSearch.GetTopDirectory(root);
           
            return Ok(content);
        }
        [Route("sizes")]
        public IHttpActionResult GetSizes(string rootDir)
        {
            string root = Uri.UnescapeDataString(rootDir);
            var sizes = FileSearch.GetFilesSizes(root);
            
            return Ok(sizes);
        }
    }
}
