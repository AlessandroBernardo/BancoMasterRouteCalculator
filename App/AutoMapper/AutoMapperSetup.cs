using App.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.DTOResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {

            #region ModelToDomain

            CreateMap<RouteModel, Route>();
            CreateMap<RankedRouteModel, RankedRouteDTO>();

            #endregion

            #region DomainToModel

            CreateMap<Route, RouteModel>();
            CreateMap<RankedRouteDTO, RankedRouteModel>();


            #endregion
        }
    }
}
