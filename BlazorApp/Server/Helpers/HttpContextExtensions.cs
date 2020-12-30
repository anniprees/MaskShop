﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace BlazorApp.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParameterInResponse<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int recordsPerPage)
        {
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("totalPages", totalPages.ToString());
        }
    }
}