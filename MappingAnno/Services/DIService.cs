﻿using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace MVVMHelper
{
    public static class DIService
    {
        public static IServiceProvider Services { get; set; }

        public static T GetDIService<T>()
        {
            var diService = Services.GetService<T>();
            Debug.Assert(diService != null);

            return diService;
        }
    }
}