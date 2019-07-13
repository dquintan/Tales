using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pasajes.Api.Entities;
using Pasajes.Api.Models;
using Pasajes.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pasajes.Api.Controllers
{
    /// <summary>
    /// 200 Sucess
    ///     200 OK
    ///     201 OK (created)
    ///     204 OK (no content), i.e sucessful delete
    /// 400 Client Error
    /// 400 Bad Request (invalid data provided)
    /// 401 Unauthorized
    /// 403 Forbidden
    /// 404 Not found
    /// 409 Conflict
    /// 500 Server Error
    /// </summary>
    [Route("api/tales")]
    public class TalesController :  Controller
    {
        private ILogger<TalesController> _logger;
        private ITalesRepository _repository;
        private IMapper _mapper;

        public TalesController(ILogger<TalesController> logger, ITalesRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GeTales()
        {
            _logger.LogInformation("GeTales hit");
            return Ok(_repository.GetTales());
        }

        [HttpGet("{id}")]
        public IActionResult GetTale(Guid id)
        {
            return Ok(_repository.GetTale(id));
        }

        [HttpPost()]
        public IActionResult CreateTale([FromBody] TaleCreationDto taleDto)
        {
            if (taleDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalTale = _mapper.Map<Tale>(taleDto);
            var result = _repository.CreateTaleAsync(finalTale);

            if (result.Result > 0)
            {
                return StatusCode(500, "Unknown error");
            }

            var tale = _mapper.Map<TaleCreationDto>(finalTale);

            return CreatedAtRoute("GetTale", new { id = finalTale.Id }, tale);
        }
    }
}