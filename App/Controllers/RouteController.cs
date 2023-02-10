using App.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        private IBaseService<Route> _baseRouteService;
        private readonly IMapper _mapper;

        public RouteController(IBaseService<Route> baseRouteService, IMapper mapper)
        {
            _baseRouteService = baseRouteService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RouteModel routeModel)
        {
            try
            {
                var route = _mapper.Map<Route>(routeModel);
                return Ok(_baseRouteService.Add<RouteValidator>(route));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromBody] RouteModel routeModel)
        {
            try
            {
                var route = _mapper.Map<Route>(routeModel);
                return Ok(_baseRouteService.Update<RouteValidator>(route));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();
                _baseRouteService.Delete(id);
                return new NoContentResult();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
                       
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                var routes = _baseRouteService.Get();
                return Ok(routes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                var route = _baseRouteService.GetById(id);
                return Ok(route);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }


}
