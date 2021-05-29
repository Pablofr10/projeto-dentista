using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Dentista.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}