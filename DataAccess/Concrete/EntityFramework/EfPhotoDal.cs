using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo, CarRentalContext>, IPhotoDal
    {
        public void AddUploadPhotoDto(UploadPhotoDto uploadPhotoDto)
        {
            Photo photo = new Photo
            {
                CarId = uploadPhotoDto.carId,
                DateAdded = DateTime.Now,
                Description = uploadPhotoDto.Description,
                IsMain = uploadPhotoDto.IsMain,
                PublicId = uploadPhotoDto.PublicId,
                Url = uploadPhotoDto.Url
            };
            this.Add(photo);
        }

        public void UpdateUploadPhotoDto(UploadPhotoDto uploadPhotoDto, Photo photo)
        {
            Photo newPhoto = new Photo
            {
                Id = photo.Id,
                CarId = uploadPhotoDto.carId,
                DateAdded = DateTime.Now,
                Description = uploadPhotoDto.Description,
                IsMain = uploadPhotoDto.IsMain,
                PublicId = uploadPhotoDto.PublicId,
                Url = uploadPhotoDto.Url
            };
            this.Update(newPhoto);
        }
    }
}
