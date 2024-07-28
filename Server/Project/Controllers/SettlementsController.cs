using Microsoft.AspNetCore.Mvc;
using BL.Interfaces;
using DAL.DTO;
using Project.Models;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettlementsController : ControllerBase
    {
        private readonly ISettlementsServices _settlementsServices;

        public SettlementsController(ISettlementsServices settlementsServices)
        {
            _settlementsServices = settlementsServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSettlements(string? nameFilter, int pageNumber, int pageSize, string? sortOrder)
        {
            var result = await _settlementsServices.GetAllSettlements(nameFilter, pageNumber, pageSize, sortOrder);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Settlements>> GetSettlementById(int id)
        {
            var settlement = await _settlementsServices.GetSettlementById(id);
            if (settlement == null)
            {
                return NotFound();
            }
            return settlement;
        }

        [HttpPost]
        public async Task<ActionResult> PostSettlements(SettlementsDto settlementsDto)
        {
            bool result = await _settlementsServices.PostSettlements(settlementsDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        //[HttpPost]
        //public async Task<ActionResult> PostSettlements(SettlementsDto settlementsDto)
        //{
        //    bool result = await _settlementsServices.PostSettlements(settlementsDto);
        //    if (!result)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSettlements(int id, SettlementsDto settlementsDto)
        {
            bool result = await _settlementsServices.PutSettlements(id, settlementsDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSettlements(int id)
        {
            bool result = await _settlementsServices.DeleteSettlements(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using BL.Interfaces;
//using DAL.DTO;
//using Project.Models;

//namespace Project.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class SettlementsController : ControllerBase
//    {
//        private readonly ISettlementsServices _settlementsServices;

//        public SettlementsController(ISettlementsServices settlementsServices)
//        {
//            _settlementsServices = settlementsServices;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<Settlements>>> GetAllSettlements()
//        {
//            return await _settlementsServices.GetAllSettlements();
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Settlements>> GetSettlementById(int id)
//        {
//            var settlement = await _settlementsServices.GetSettlementById(id);
//            if (settlement == null)
//            {
//                return NotFound();
//            }
//            return settlement;
//        }

//        [HttpPost]
//        public async Task<ActionResult> PostSettlements(SettlementsDto settlementsDto)
//        {
//            bool result = await _settlementsServices.PostSettlements(settlementsDto);
//            if (!result)
//            {
//                return BadRequest();
//            }
//            return Ok();
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> PutSettlements(int id, SettlementsDto settlementsDto)
//        {
//            bool result = await _settlementsServices.PutSettlements(id, settlementsDto);
//            if (!result)
//            {
//                return BadRequest();
//            }
//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteSettlements(int id)
//        {
//            bool result = await _settlementsServices.DeleteSettlements(id);
//            if (!result)
//            {
//                return NotFound();
//            }
//            return Ok();
//        }
//    }
//}
