using App.Models;
using AutoMapper;
using Domain.Entities;
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

            #endregion

            #region DomainToModel

            CreateMap<Route, RouteModel>();


            #endregion
        }
    }
}
