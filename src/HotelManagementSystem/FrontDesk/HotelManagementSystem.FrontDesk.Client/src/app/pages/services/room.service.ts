import { Injectable } from '@angular/core';
import { Room } from '../interface/room.interface';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private rooms: Room[] = []; //Placeholder for rooms data


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

deleteRoom(room: Room): void {
  this.rooms = this.rooms.filter(room => room.id !== id);
}


  getAvailableRooms(): Room[] {
    return this.rooms.filter(room => room.available);
  }

    getRoomById(id: number): Room | undefined { 
      return this.rooms.find(room => room.id === id);
    }
  }

