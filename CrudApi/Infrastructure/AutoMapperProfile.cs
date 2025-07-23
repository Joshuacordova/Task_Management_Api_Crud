using AutoMapper;
using CrudApi.Models;
using CrudApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApi.Infrastructure
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile() 
		{
			CreateMap<TaskModel, TaskDto>();
			
			CreateMap<TaskModel, CreateTaskDto>();
            CreateMap<CreateTaskDto, TaskModel>();

            CreateMap<TaskModel, UpdateTaskDto>();
            CreateMap<UpdateTaskDto, TaskModel>();
        }
	}
}