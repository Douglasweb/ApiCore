using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}", Name="GetPrimaryById")]
        public ActionResult <PrimaryReadDto> GetPrimaryById(int id){
            
            var primaryitem = _repository.GetPrimaryById(id);
            if(primaryitem != null) 
                return Ok(_mapper.Map<PrimaryReadDto>(primaryitem));
            else
                return NotFound();
            
        }

        [HttpPost]
        public ActionResult <PrimaryReadDto> CreatePrimary(PrimaryCreateDto primaryCreatedto)
        {            
            var PrimaryModel = _mapper.Map<Primary>(primaryCreatedto);
            _repository.CreatePrimary(PrimaryModel);
            _repository.Savechanges();

            var readdto = _mapper.Map<PrimaryReadDto>(PrimaryModel);

            return CreatedAtRoute(nameof(GetPrimaryById), new {Id = readdto.Id},readdto);
            
        }


        [HttpPut("{id}")]
        public ActionResult UpdatePrimary(int id, PrimaryUpdateDto primaryUpdatedto)
        {            
            var PrimaryModelfromRepo = _repository.GetPrimaryById(id);
            if(PrimaryModelfromRepo == null) 
                return NotFound();
            

            _mapper.Map(primaryUpdatedto, PrimaryModelfromRepo);

            //Chamado por boas praticas, caso haja alguma coisa a mais a fazer, mas nao e necessario.
            _repository.UpdatePrimary(PrimaryModelfromRepo);

            _repository.Savechanges();

            return NoContent();
            
        }


        [HttpPatch("{id}")]
        public ActionResult PartialPrimaryUpdate(int id, JsonPatchDocument<PrimaryUpdateDto> patchDoc)
        {
            var PrimaryModelfromRepo = _repository.GetPrimaryById(id);
            if(PrimaryModelfromRepo == null) 
                return NotFound();

            
            var primaryToPatch = _mapper.Map<PrimaryUpdateDto>(PrimaryModelfromRepo);

            patchDoc.ApplyTo(primaryToPatch, ModelState);

            if(!TryValidateModel(primaryToPatch))
            {
                return ValidationProblem(ModelState);
            }

             _mapper.Map(primaryToPatch, PrimaryModelfromRepo);

            //Chamado por boas praticas, caso haja alguma coisa a mais a fazer, mas nao e necessario.
            _repository.UpdatePrimary(PrimaryModelfromRepo);

            _repository.Savechanges();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public ActionResult DeletePrimary(int id)
        {
            var PrimaryModelfromRepo = _repository.GetPrimaryById(id);

            if(PrimaryModelfromRepo == null) 
                return NotFound();    
            
            //Chamado por boas praticas, caso haja alguma coisa a mais a fazer, mas nao e necessario.
            _repository.DeletePrimary(PrimaryModelfromRepo);

            _repository.Savechanges();

            return NoContent();
        }

    }

}