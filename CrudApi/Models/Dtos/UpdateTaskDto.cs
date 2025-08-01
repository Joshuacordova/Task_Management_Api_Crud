﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApi.Models.Dtos
{
	public class UpdateTaskDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}