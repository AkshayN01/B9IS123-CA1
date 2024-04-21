// room.interface.ts
export interface Room {
    roomid: number;
    roomNumber: string;
    type: string;
    capacity: number;
    price: number;
    available: boolean;
}