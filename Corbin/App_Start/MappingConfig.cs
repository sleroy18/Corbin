﻿using Corbin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corbin.App_Start
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<MyProject, ProjectViewModel>().ReverseMap();
                config.CreateMap<MyProject, ProjectCreateViewModel>().ReverseMap();
                //config.CreateMap<Project, ProjectDetailsViewModel>().ReverseMap();
                //config.CreateMap<Project, ProjectDeleteViewModel>().ReverseMap();

            });
        }
        
    }
}