using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _unitOfWork.Product.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _unitOfWork.Product.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("Add")]
        public IActionResult Add(Products Products)
        {
            _unitOfWork.Product.AddAsync(Products);
            _unitOfWork.Save();
            return Ok("Products added successfully");
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<Products> Productss)
        {
            _unitOfWork.Product.AddRangeAsync(Productss);
            _unitOfWork.Save();
            return Ok("Products added successfully");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Products Products)
        {
            _unitOfWork.Product.DeleteAsync(Products);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpDelete("DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<Products> Productss)
        {
            _unitOfWork.Product.DeleteRange(Productss);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpPost("Update")]
        public IActionResult Update(Products Products)
        {
            _unitOfWork.Product.UpdateAsync(Products);
            _unitOfWork.Save();
            return Ok("Products Updated Successfully");
        }
    }
}
