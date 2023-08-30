using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalerAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WholesalerAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _unitOfWork.Wholesaler.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id) 
        {
            var data = _unitOfWork.Wholesaler.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("Add")]
        public IActionResult Add(Wholesaler wholesaler)
        {
            _unitOfWork.Wholesaler.AddAsync(wholesaler);
            _unitOfWork.Save();
            return Ok("Wholesaler added successfully");
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<Wholesaler> wholesalers)
        {
            _unitOfWork.Wholesaler.AddRangeAsync(wholesalers);
            _unitOfWork.Save();
            return Ok("Wholesalers added successfully");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Wholesaler wholesaler)
        {
            _unitOfWork.Wholesaler.DeleteAsync(wholesaler);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpDelete("DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<Wholesaler> wholesalers)
        {
            _unitOfWork.Wholesaler.DeleteRange(wholesalers);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpPost("Update")]
        public IActionResult Update(Wholesaler wholesaler)
        {
            _unitOfWork.Wholesaler.UpdateAsync(wholesaler);
            _unitOfWork.Save();
            return Ok("Wholesaler Updated Successfully");
        }
    }
}
