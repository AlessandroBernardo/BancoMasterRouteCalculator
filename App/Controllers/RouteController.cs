using App.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;
using System;
using System.Collections.Generic;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        private readonly IBaseService<Route> _baseRouteService;
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;        
        private readonly ICustomRoutesValidators _customRoutesValidators;
        public RouteController(IBaseService<Route> baseRouteService, IMapper mapper, IRouteService routeService, ICustomRoutesValidators customRoutesValidators)
        {
            //acesso as interfaces genéricas
            _baseRouteService = baseRouteService;
            // acesso as interfaces específicas
            _routeService = routeService;
            _mapper = mapper;
            _customRoutesValidators = customRoutesValidators;
            
        }

        /// <summary>
        /// Endpoint que tem que como função trazer a rota de menor valor entre dois pontos.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("{origin}/{destination}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CheckCheapestRoute(string origin, string destination)
        {
            try
            {
                var listDto = _routeService.CheckCheapestRoute(origin, destination);
                return Ok(_mapper.Map<IList<RankedRouteModel>>(listDto));                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RouteModel routeModel)
        {
            try
            {
                var route = _mapper.Map<Route>(routeModel);              
                if (_customRoutesValidators.RouteExists(route))
                {
                    return BadRequest("Essa rota já existe");
                }                               
                return Ok(_baseRouteService.Add<RouteValidator>(route));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        } 
        
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return NotFound();
                _baseRouteService.Delete(id);
                return new NoContentResult();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(Guid id)
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
