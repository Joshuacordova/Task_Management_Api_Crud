using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApi.Infrastructure
{
	public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(string message) : base(message) { }
        public TaskNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class AppException : Exception
    {
        public AppException(string message) : base(message) { }
        public AppException(string message, Exception innerException) : base(message, innerException) { }
    }
}