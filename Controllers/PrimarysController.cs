using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Primeiro.Data;
using Primeiro.Models;

namespace Primeiro.Controllers {


    //api/primarys
    [Route("api/primarys")]
    [ApiController]
    public class PrimarysController : ControllerBase
    {

        private readonly MockPrimeiroRepo _repository = new MockPrimeiroRepo();

        [HttpGet]
        public ActionResult<IEnumerable<Primary>> GetAllPrimary()
        {
            var primaryitems = _repository.GetAppPrimary();

            return Ok(primaryitems);

        }

        [HttpGet("{id}")]
        public ActionResult <Primary> GetPrimaryById(int id){
            
            var primaryitem = _repository.GetPrimaryById(id);

            return Ok(primaryitem);
        }

    }

}