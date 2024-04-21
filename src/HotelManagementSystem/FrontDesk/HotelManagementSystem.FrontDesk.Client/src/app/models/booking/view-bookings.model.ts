export interface Booking {
    totalData: Number,
    bookingInfo: BookingInfo[]
}

interface BookingInfo{
  id:number;
  fromDate: string;
  toDate: string;
  status: string;
  visitorName: string
}