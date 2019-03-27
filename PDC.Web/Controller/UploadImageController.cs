using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PDC.Web.Controller
{
    [Produces("application/json")]
    [Route("api/UploadImage")]
    public class UploadImageController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public void UploadImage(string imageData, string imageName)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string fileNameWitPath = webRootPath + "/images/graph/" + imageName + ".png";
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
        }
    }
}