﻿using BeOn.Filters;
using BeOn.Models;
using BeOn.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BeOn.Controllers
{
    [Route("api/[controller]/[action]/{deviceId}")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly EnvironmentRepository _environmentRepository;
        private readonly DeviceRepository _deviceRepository;
        private readonly PercentageFormatter _percentageFormatter;

        public DeviceController(DeviceRepository deviceRepository,
                                EnvironmentRepository environmentRepository,
                                PercentageFormatter percentageFormatter)
        {
            _deviceRepository = deviceRepository;
            _environmentRepository = environmentRepository;
            _percentageFormatter = percentageFormatter;
        }

        [ActionName("Battery")]
        [HttpGet]
        public IActionResult GetBatteryLevels([FromRoute] String deviceId, 
                                              [FromQuery] TimestampFilter<DeviceEnvironment> filter)
        {
            Device device = _deviceRepository.FindById(deviceId);
            IQueryable<DeviceEnvironment> environments = _environmentRepository.FindAllByDevice(device);
            IEnumerable<Double> batteryLevels = filter.Apply(environments)
                                                      .Select(environment => environment.BatteryLevel);
            return Ok(_percentageFormatter.FormatMany(batteryLevels));
        }

        [ActionName("Temperatures")]
        [HttpGet]
        public IActionResult GetTemperatures([FromRoute] String deviceId,
                                             [FromQuery] TimestampFilter<DeviceEnvironment> filter)
        {
            Device device = _deviceRepository.FindById(deviceId);
            IQueryable<DeviceEnvironment> environments = _environmentRepository.FindAllByDevice(device);
            var temperatures = filter.Apply(environments).Select((environment) => new Dictionary<String, Int32>
            {
                { "timestamp", environment.Timestamp.Millisecond },
                { "min", environment.MinimumTemperature },
                { "max", environment.MaximumTemperature },
                { "mean", (environment.MinimumTemperature + environment.MaximumTemperature) / 2 }
            });
            return Ok(temperatures);
        }
        [ActionName("TemperaturesBetween")]
        [HttpGet]
         public IActionResult GetTemperatureBetween([FromRoute] String deviceId,
                                                [FromQuery] DateTimeFilter<DeviceEnvironment>filter)
		{
            Device device = _deviceRepository.FindById(deviceId);
            IQueryable<DeviceEnvironment> environments = _environmentRepository.FindAllByDevice(device);
            var temperatures = filter.Apply(environments).Select((environment)=>new Dictionary<String,Int32>
            {
                    { "timestamp", environment.Timestamp.Millisecond },
                { "min", environment.MinimumTemperature },
                { "max", environment.MaximumTemperature },
                { "mean", (environment.MinimumTemperature + environment.MaximumTemperature) / 2 }
            });
            return Ok(temperatures);

        }

        [ActionName("Contact")]
        [HttpGet]
        public IActionResult GetContacts([FromRoute] String deviceId,
                                                            [FromQuery] TimestampFilter<DeviceEnvironment> filter)
		{
            Device device = _deviceRepository.FindById(deviceId);
            IQueryable<DeviceEnvironment> environments = _environmentRepository.FindAllByDevice(device);
            IEnumerable<String> dateTimes = filter.Apply(environments)
                                                        .Select(environments => environments.Timestamp.ToString("f", DateTimeFormatInfo.InvariantInfo));
            return Ok(dateTimes);
        }

    }
}