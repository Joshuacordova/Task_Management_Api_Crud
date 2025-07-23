using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CrudApi.Infrastructure.Helpers
{
	public class TableNameResolver
	{
        public static string GetTableName<T>()
        {
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            return tableAttr != null ? tableAttr.Name : type.Name;
        }
    }
}