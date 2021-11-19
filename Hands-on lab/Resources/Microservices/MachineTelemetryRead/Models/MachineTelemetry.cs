using System;
using System.Collections.Generic;

namespace MachineTelemetryRead.Models
{

    public class MachineTelemetry
    {
        public Guid Id { get; set; }
        public int? MachineId { get; set; }
        public Guid Event_Id { get; set; }
        public string Event_Type { get; set; }
        public string Entity_Type { get; set; }
        public Guid Entity_Id { get; set; }
        public string Event_Data { get; set; }
    }

    public class EventData
    {
        public int FactoryId { get; set; }
        public MachineData Machine { get; set; }
        public MachineAmbientData Ambient { get; set; }
        public DateTime TimeCreated { get; set; }
    }

    public class MachineData
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double ElectricityUtilization { get; set; }
    }
    public class MachineAmbientData
    {
        public double Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
