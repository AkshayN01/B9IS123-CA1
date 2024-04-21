import { VisitorModel } from "../visitor/visitor.model";

export interface BookingRegisterModel{
    fromDate: string,
    toDate: string,
    roomIds : Number[],
    visitors: VisitorModel[]
}