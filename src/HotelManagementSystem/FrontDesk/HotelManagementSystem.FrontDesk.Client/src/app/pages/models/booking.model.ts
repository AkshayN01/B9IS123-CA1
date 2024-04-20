export interface Booking {
    id:number;
    fromDate: string;
  toDate: string;
  branchId: number;
  visitorDetails: {
    visitorId: number;
    firstName: string;
    middleName: string;
    lastName: string;
    emailId: string;
    phoneNo: string;
    isPrimary: number;
  };
}