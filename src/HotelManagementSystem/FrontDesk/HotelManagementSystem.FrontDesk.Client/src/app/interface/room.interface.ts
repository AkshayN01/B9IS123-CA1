// room.interface.ts
export interface Room {
    id: number;
    roomNumber: string;
    type: string;
    capacity: number;
    price: number;
    available: boolean;
}