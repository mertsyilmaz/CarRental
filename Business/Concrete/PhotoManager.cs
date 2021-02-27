using Business.Abstract;
using Business.Constants;
using Business.ImageProcesses.ToCloudinary;
using Business.ImageProcesses.ToLocal;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PhotoManager : IPhotoManager
    {
        private IPhotoDal _photoDal;

        public PhotoManager(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }

        public IResult Add(UploadPhotoDto uploadPhotoDto)
        {
            var result = CloudImageProcesses.UploadImage(uploadPhotoDto);
            //string url = LocalImageProcesses.UploadImage(uploadPhotoDto.file);
            _photoDal.AddUploadPhotoDto(result);
            return new SuccessResult(Messages.PhotoAdded);
        }

        public IResult Delete(Photo photo)
        {
            // LocalImageProcesses.DeleteImage(photo.Url);
            CloudImageProcesses.DeleteImage(photo);
            _photoDal.Delete(photo);
            return new SuccessResult(Messages.PhotoDeleted);
        }


        public IDataResult<Photo> GetByCarId(int carId)
        {
            return new SuccessDataResult<Photo>(_photoDal.Get(p => p.CarId == carId && p.IsMain == true), Messages.PhotoListed);
        }

        public IDataResult<List<Photo>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetAll(x => x.CarId == carId), Messages.PhotoListed);
        }

        public IResult Update(int photoId, UploadPhotoDto uploadPhotoDto)
        {
            var photo = _photoDal.Get(p => p.Id == photoId);
            var result = CloudImageProcesses.UpdateImage(uploadPhotoDto, photo);
            // string url = LocalImageProcesses.UpdateImage(uploadPhotoDto,photo);
            _photoDal.UpdateUploadPhotoDto(result, photo);
            return new SuccessResult(Messages.PhotoUpdated);
        }
    }
}
