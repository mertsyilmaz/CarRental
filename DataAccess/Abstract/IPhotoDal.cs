using Entities.Concrete;
using Entities.DTOs;
using Global.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPhotoDal: IEntityRepository<Photo>
    {
        void AddUploadPhotoDto(UploadPhotoDto uploadPhotoDto);

        void UpdateUploadPhotoDto(UploadPhotoDto uploadPhotoDto, Photo photo);
    }
}
