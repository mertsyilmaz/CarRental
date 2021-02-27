using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.ImageProcesses.ToCloudinary
{
    public class CloudImageProcesses
    {
        

        public static UploadPhotoDto UploadImage(UploadPhotoDto uploadPhotoDto)
        {
             Account account = new Account(CloudinarySettings.CloudName, CloudinarySettings.ApiKey, CloudinarySettings.ApiSecret);

            Cloudinary cloudinary = new Cloudinary(account);

            var file = uploadPhotoDto.file;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }
            uploadPhotoDto.Url = uploadResult.Url.ToString();
            uploadPhotoDto.PublicId = uploadResult.PublicId;

            return uploadPhotoDto;
        }

        public static void DeleteImage(Photo photo)
        {
            Account account = new Account(CloudinarySettings.CloudName, CloudinarySettings.ApiKey, CloudinarySettings.ApiSecret);

            Cloudinary cloudinary = new Cloudinary(account);

            var delResParams = new DelResParams()
            {
                PublicIds = new List<string> { photo.PublicId }
            };
            cloudinary.DeleteResources(delResParams);
        }

        public static UploadPhotoDto UpdateImage(UploadPhotoDto uploadPhotoDto,Photo photo)
        {
            Account account = new Account(CloudinarySettings.CloudName, CloudinarySettings.ApiKey, CloudinarySettings.ApiSecret);

            Cloudinary cloudinary = new Cloudinary(account);

            var file = uploadPhotoDto.file;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }
            uploadPhotoDto.Url = uploadResult.Url.ToString();
            uploadPhotoDto.PublicId = uploadResult.PublicId;

            DeleteImage(photo);

            return uploadPhotoDto;
        }
    }
}
