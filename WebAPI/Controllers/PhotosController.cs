using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IPhotoManager _photoManager;

        public PhotosController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }

        [HttpGet("getphotosbycarid")]
        public IActionResult GetAllPhoto(int carId)
        {
            var result = _photoManager.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getmainphoto")]
        public IActionResult GetMainPhoto(int carId)
        {
            var result = _photoManager.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addphotoforcar")]
        public IActionResult AddPhotoForCar([FromForm] UploadPhotoDto photoDto)
        {
            var result = _photoManager.Add(photoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletephotoforcar")]
        public IActionResult DeletePhotoForCar(Photo photo)
        {
            var result = _photoManager.Delete(photo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updatephotoforcar")]
        public IActionResult UpdatePhotoForCar(int PhotoId, [FromForm] UploadPhotoDto photoDto)
        {
            var result = _photoManager.Update(PhotoId, photoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
