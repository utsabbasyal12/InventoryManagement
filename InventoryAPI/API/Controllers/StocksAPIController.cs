using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StocksAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _unitOfWork.Stock.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _unitOfWork.Stock.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("Add")]
        public IActionResult Add(Stocks Stocks)
        {
            _unitOfWork.Stock.AddAsync(Stocks);
            _unitOfWork.Save();
            return Ok("Stocks added successfully");
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<Stocks> Stocks)
        {
            _unitOfWork.Stock.AddRangeAsync(Stocks);
            _unitOfWork.Save();
            return Ok("Stocks added successfully");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Stocks Stocks)
        {
            _unitOfWork.Stock.DeleteAsync(Stocks);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpDelete("DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<Stocks> Stocks)
        {
            _unitOfWork.Stock.DeleteRange(Stocks);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpPost("Update")]
        public IActionResult Update(Stocks Stocks)
        {
            _unitOfWork.Stock.UpdateAsync(Stocks);
            _unitOfWork.Save();
            return Ok("Stocks Updated Successfully");
        }
    }
}
