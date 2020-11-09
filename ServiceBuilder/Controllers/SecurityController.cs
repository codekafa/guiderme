using Business.Service.Common;
using Business.Service.Infrastructure;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilder.Controllers.Base;
using ServiceBuilder.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace ServiceBuilder.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
  {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //ISecurityService _securtyService;
        //ITokenEngine  _tokenEngine;
        //public SecurityController(ISecurityService securtyService, ITokenEngine tokenEngine)
        //{
        //    _securtyService = securtyService;
        //    _tokenEngine = tokenEngine;
        //}

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public CommonResult Login(LoginUserModel loginUser)
        {
            return new CommonResult();
        }

        [MethodAuthServiceFilter(new int[2] { 1, 2 })]
        public CommonResult GetUser()
        {
            return new CommonResult();
        }

    }
}
