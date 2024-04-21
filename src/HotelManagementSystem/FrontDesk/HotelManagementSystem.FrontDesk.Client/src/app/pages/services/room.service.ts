import { Injectable } from '@angular/core';
import { Room } from '../interface/room.interface';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private room: Room[] = []; //Placeholder for rooms data


  constructor() { }

addRoom(room: Room): void {
  room.id = Date.now();
  this.rooms.push(room);
}


updateRoom(room: Room): void {
  const index = this.rooms.findIndex(r => r.id === room.id);
  if ( index !== -1) {
    this.rooms[index] = room;
  }
}

deleteRoom(id: number): void {
  this.rooms = this.rooms.filter(room.id !== id);
}


  getAllRooms(): Room[] {
    return this.room;
  }

    getRoomById(id: number): Room | undefined { 
      return this.rooms.find(room => room.id === id);
    }
  }

