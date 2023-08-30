using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _unitOfWork.Category.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _unitOfWork.Category.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("Add")]
        public IActionResult Add(Categories Categories)
        {
            _unitOfWork.Category.AddAsync(Categories);
            _unitOfWork.Save();
            return Ok("Categories added successfully");
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<Categories> Categories)
        {
            _unitOfWork.Category.AddRangeAsync(Categories);
            _unitOfWork.Save();
            return Ok("Categories added successfully");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Categories Categories)
        {
            _unitOfWork.Category.DeleteAsync(Categories);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpDelete("DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<Categories> Categories)
        {
            _unitOfWork.Category.DeleteRange(Categories);
            _unitOfWork.Save();
            return Ok("Successfully Deleted");
        }
        [HttpPost("Update")]
        public IActionResult Update(Categories Categories)
        {
            _unitOfWork.Category.UpdateAsync(Categories);
            _unitOfWork.Save();
            return Ok("Categories Updated Successfully");
        }
    }
}
