using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductPriceAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _unitOfWork.ProductPrice.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _unitOfWork.ProductPrice.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("Add")]
        public IActionResult Add(ProductPrice ProductPrice)
        {
            _unitOfWork.ProductPrice.AddAsync(ProductPrice);
            _unitOfWork.Save();
            return Ok("ProductPrice added successfully");
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<ProductPrice> ProductPrices)
        {
            _unitOfWork.ProductPrice.AddRangeAsync(ProductPrices);
            _unitOfWork.Save();
            return Ok("ProductPrices added successfully");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(ProductPrice ProductPrice)
        {
            _unitOfWork.ProductPrice.DeleteAsync(ProductPrice);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpDelete("DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<ProductPrice> ProductPrices)
        {
            _unitOfWork.ProductPrice.DeleteRange(ProductPrices);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpPost("Update")]
        public IActionResult Update(ProductPrice ProductPrice)
        {
            _unitOfWork.ProductPrice.UpdateAsync(ProductPrice);
            _unitOfWork.Save();
            return Ok("ProductPrice Updated Successfully");
        }
    }
}
