﻿using Business.Abstract;
using Entities.Concrete;
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
    public class CarsController : ControllerBase
    {
        ICarManager _carManager;

        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);
            if (result.Success)
            {
               return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carManager.GetCarsByBrandId(id);
            if (result.Success)
            {
              return  Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carManager.GetCarsByColorId(id);
            if (result.Success)
            {
               return  Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carManager.GetCarDetails();
            if (result.Success)
            {
               return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailbyid")]
        public IActionResult GetCarDetailById(int carId)
        {
            var result = _carManager.GetCarDetailById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbybrandId")]
        public IActionResult GetCarDetailsByBrandId(int brandId)
        {
            var result = _carManager.GetCarDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbycolorId")]
        public IActionResult GetCarDetailsByColorId(int colorId)
        {
            var result = _carManager.GetCarDetailsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbyfilter")]
        public IActionResult GetCarDetailsByFilter(int? colorId,int? brandId)
        {
            var result = _carManager.GetCarDetailsByFilter(colorId,brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
