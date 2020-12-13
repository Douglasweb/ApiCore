using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Primeiro.Data;
using Primeiro.Dtos;
using Primeiro.Models;

namespace Primeiro.Controllers {


    //api/primarys
    [Route("api/primarys")]
    [ApiController]
    public class PrimarysController : ControllerBase
    {
        private readonly IPrimeiroRepo _repository;
        private readonly IMapper _mapper;

        public PrimarysController(IPrimeiroRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        [HttpGet]
        public ActionResult<IEnumerable<PrimaryReadDto>> GetAllPrimary()
        {
            var primaryitems = _repository.GetAllPrimary();

            if(primaryitems != null) 
                return Ok(_mapper.Map<IEnumerable<PrimaryReadDto>>(primaryitems));
            else
                return NotFound();            

        }

        [HttpGet("{id}")]
        public ActionResult <PrimaryReadDto> GetPrimaryById(int id){
            
            var primaryitem = _repository.GetPrimaryById(id);
            if(primaryitem != null) 
                return Ok(_mapper.Map<PrimaryReadDto>(primaryitem));
            else
                return NotFound();
            
        }

    }

}