using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Common.DTOs;
using MachineTelemetryRead.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MachineTelemetryRead.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineTelemetryController
    {
        private IEventRepository _eventRepository;

        public MachineTelemetryController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<List<MachineTelemetryDto>> GetAsync([FromQuery] int limit = 100, [FromQuery] int skip = 0)
        {
            return (await _eventRepository.GetAllEventsAsync(limit, skip))
                .Select(e =>
                {
                    var eventData = JsonSerializer.Deserialize<MachineTelemetryRead.Models.EventData>(e.Event_Data,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                    return new MachineTelemetryDto
                    {
                        Id = e.Id,
                        MachineId = e.MachineId,
                        EventId = Guid.NewGuid(),
                        EventType = e.Event_Type,
                        EntityType = e.Entity_Type,
                        EntityId = e.Entity_Id,
                        FactoryId = eventData.FactoryId,
                        Machine = new MachineData
                        {
                            Temperature = eventData.Machine.Temperature,
                            Pressure = eventData.Machine.Pressure,
                            ElectricityUtilization = eventData.Machine.ElectricityUtilization,
                        },
                        Ambient = new MachineAmbientData
                        {
                            Temperature = eventData.Ambient.Temperature,
                            Humidity = eventData.Ambient.Humidity,
                        },
                        TimeCreated = eventData.TimeCreated
                    };
                })
                .ToList();
        }
    }
}