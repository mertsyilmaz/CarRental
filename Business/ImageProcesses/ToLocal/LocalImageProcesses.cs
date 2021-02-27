using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.ImageProcesses.ToLocal
{
    public class LocalImageProcesses
    {
        public static UploadPhotoDto UploadImage(UploadPhotoDto uploadPhotoDto)
        {
            string filePath = null;
            if (uploadPhotoDto.file != null)
            {
                string uploadsFolder = Path.GetTempPath();
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + uploadPhotoDto.file.FileName;
                filePath = Path.Combine(uploadsFolder, "CarRental", "Images", uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadPhotoDto.file.CopyTo(fileStream);
                }
                uploadPhotoDto.Url = filePath;
            }
            return uploadPhotoDto;
        }

        public static void DeleteImage(Photo photo)
        {
            if (photo != null)
            {
                if (File.Exists(photo.Url))
                {
                    File.Delete(photo.Url);
                }
            }
        }

        public static UploadPhotoDto UpdateImage(UploadPhotoDto uploadPhotoDto,Photo photo)
        {
            if (uploadPhotoDto.file != null)
            {
                string uploadsFolder = Path.GetTempPath();
                if (File.Exists(photo.Url))
                {
                    DeleteImage(photo);
                }
                return UploadImage(uploadPhotoDto);
            }
            else
            {
                return uploadPhotoDto;
            }
        }
    }
}
