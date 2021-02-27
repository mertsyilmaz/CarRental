using Entities.Concrete;
using Entities.DTOs;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPhotoManager
    {
        IDataResult<List<Photo>> GetAllByCarId(int carId);

        IDataResult<Photo> GetByCarId(int carId);

        IResult Add(UploadPhotoDto uploadPhotoDto);

        IResult Update(int photoId, UploadPhotoDto uploadPhotoDto);

        IResult Delete(Photo photo);
    }
}
