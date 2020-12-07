using GeoToDo.WebApi.Enums;
using GeoToDo.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeoToDo.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFileAsync(IFormFile file, string contentType)
        {
            UploadModel uploadModel = new UploadModel();

            if (file != null)
            {
                if (file.ContentType!=contentType)
                {
                    uploadModel.ErrorMessage = "This type of file is not supported";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Succes;
                    return uploadModel;
                }
            }

            uploadModel.ErrorMessage = "Didn't update any file";
            uploadModel.UploadState = UploadState.NotExist;
            return uploadModel;
        }
    }
}
