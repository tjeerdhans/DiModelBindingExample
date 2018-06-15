﻿using System;
using Newtonsoft.Json.Serialization;

namespace DiModelBindingExample.Infrastructure
{
    public class DiCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public DiCamelCasePropertyNamesContractResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var result = base.CreateObjectContract(objectType);

            var instance = _serviceProvider.GetService(objectType);            
            if (instance != null)
            {               
                result.DefaultCreator = () => _serviceProvider.GetService(objectType);
             
            }

            return result;
        }
    }
}
