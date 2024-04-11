import { PatientModel } from "./patient.model";

export class AppointmentModel{
    id: string = "";
    startDate: string = "";
    endDate: string = "";
    title: string = "";
    patient: PatientModel = new PatientModel();    
}