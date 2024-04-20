

export interface Booking {
    id: number;
    fromDate: string;
    toDate: string;
    branchId: number;
    room: [];
    visitors: Visitor[];
}

export interface Room {
    id: number;
    level: number;
    roomNumber: number;
    roomType: string;
    roomName: string;
}

export interface Visitor {
    id: number;
    firstName: string;
    middleName: string;
    lastName: string;
    email: string | null;
    phone: number | null;
    isPrimary: number;
}
