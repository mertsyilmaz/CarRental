using Business.Abstract;
using Business.Constants;
using Business.ImageProcesses.ToCloudinary;
using Business.ImageProcesses.ToLocal;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.Utilities.Business;
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
            IResult result = BusinessRules.Run(
                CheckImageCount(uploadPhotoDto.carId)
                );
            if (result != null)
            {
                return result;
            }

            //string url = LocalImageProcesses.UploadImage(uploadPhotoDto.file);
            var uploadResult = CloudImageProcesses.UploadImage(uploadPhotoDto);
            _photoDal.AddUploadPhotoDto(uploadResult);
            return new SuccessResult(Messages.PhotoAdded);
        }

        public IResult Delete(Photo photo)
        {
            IResult result = BusinessRules.Run(
                PhotoExists(photo.Id)
                );
            if (result != null)
            {
                return result;
            }

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
            IResult result = BusinessRules.Run(
                PhotoExists(photoId),
                CheckImageCount(uploadPhotoDto.carId)
                );
            if (result != null)
            {
                return result;
            }

            var photo = _photoDal.Get(p => p.Id == photoId);
            var updateResult = CloudImageProcesses.UpdateImage(uploadPhotoDto, photo);
            // string url = LocalImageProcesses.UpdateImage(uploadPhotoDto,photo);
            _photoDal.UpdateUploadPhotoDto(updateResult, photo);
            return new SuccessResult(Messages.PhotoUpdated);
        }

        private IResult CheckImageCount(int carId)
        {
            if (_photoDal.GetAll(p => p.CarId == carId).Count <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PhotoCountLimit);
        }

        private IResult PhotoExists(int photoId)
        {
            if (_photoDal.Get(p => p.Id == photoId) != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PhotoNotFound);
        }
    }
}
