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
            var temperatures = filter.Apply(environments).Select((environment) => new Dictionary<String, String>
            {
                { "timestamp", environment.Timestamp.ToString() },
                { "min", environment.MinimumTemperature.ToString() },
                { "max", environment.MaximumTemperature.ToString() },
                { "mean", ((environment.MinimumTemperature + environment.MaximumTemperature) / 2).ToString() }
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
            var temperatures = filter.Apply(environments).Select((environment)=>new Dictionary<String,String>
            {
                    { "timestamp", environment.Timestamp.ToString() },
                { "min", environment.MinimumTemperature.ToString() },
                { "max", environment.MaximumTemperature.ToString() },
                { "mean", ((environment.MinimumTemperature + environment.MaximumTemperature) / 2).ToString() }
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

        [ActionName("MapContainer")]
        [HttpGet]
        public IActionResult GetCoordinates([FromRoute] String deviceId,
                                               [FromQuery] TimestampFilter<DeviceEnvironment> filter)
        {
            Device device = _deviceRepository.FindById(deviceId);
            IQueryable<DeviceEnvironment> environments = _environmentRepository.FindAllByDevice(device);
            var coordinates = filter.Apply(environments).Select((environment) => new Dictionary<String, Double>
                {
                    { "latitude", Math.Round(environment.ComputedLatitude,6) },
                    { "longitude", Math.Round(environment.ComputedLongitude,6) },
                });
			return Ok(coordinates);
        }


        [ActionName("Alert")]
        [HttpGet]
        public IActionResult GetAlerts([FromRoute] String deviceId,
                                            [FromQuery] TimestampFilter<DeviceEnvironment> filter)
        {
            Device device = _deviceRepository.FindById(deviceId);
            IQueryable<DeviceEnvironment> environments = _environmentRepository.FindAllByDevice(device);

			IQueryable<Dictionary<string, string>> alerts = filter.Apply(environments).Where(e => (e.EventType == "1" || e.EventType == "3")).Select((environment) => new Dictionary<String, String> 
            {
                 { "timestamp", environment.Timestamp.ToString() },
                { "latitude", Math.Round(environment.ComputedLatitude,6).ToString() },
                { "longitude", Math.Round(environment.ComputedLongitude,6).ToString() },
                { "eventType", Convert.ToInt32(environment.EventType).ToString() },
                { "maxShock", environment.Smax.ToString() }
            });

            return Ok(alerts);
        }
    }
}