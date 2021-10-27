export interface IMachineTelemetryDto {
	id: string;
	machineId?: number;
	eventId: string;
	eventType: string;
	entityType: string;
	entityId: string;
	factoryId: number;
	machine: IMachineData;
	ambient: IMachineAmbientData;
	timeCreated: Date;
}

export interface IMachineData {
	machineId: number;
	temperature: number;
	pressure: number;
	electricityUtilization: number;
}

export interface IMachineAmbientData {
	temperature: number;
	humidity: number;
}