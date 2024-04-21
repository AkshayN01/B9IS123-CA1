import { Component } from '@angular/core';
import { RoomService } from '../../services/room.service';
import { Room } from '../../../inter/room.interface';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrls: ['./room-create.component.css']
})
export class RoomCreateComponent {
  roomForm: FormGroup;
  rooms: Room[] = [];
  selectedRoom: Room | null = null;
  showAddRoomForm: boolean = false;

  constructor(private roomService: RoomService, private formBuilder: FormBuilder) {
    this.roomForm = this.formBuilder.group({
      roomNumber: [''],
      type: [''],
      capacity: [''],
      price: [''],
      available: [false]
    });
    this.rooms = this.roomService.getAllRooms();
    this.selectedRoom = {
      roomid: 0,
      roomNumber: '',
      type: '',
      capacity: 0,
      price: 0,
      available: false
    };
  }
  

  openAddRoomForm(): void {
    this.showAddRoomForm = true;
  }

  addRoom(): void {
    const newRoom: Room = this.roomForm.value;
    this.roomService.addRoom(newRoom);
    this.resetForm();
    this.rooms = this.roomService.getAvailableRooms(); // Updated method name
    this.showAddRoomForm = false;
  }

  cancelAddRoom(): void {
    this.resetForm();
    this.showAddRoomForm = false;
  }

  updateRoom(): void {
    if (this.selectedRoom) {
      this.roomService.updateRoom(this.selectedRoom);
      this.selectedRoom = null;
    }
  }

  cancelUpdate(): void {
    this.selectedRoom = null;
  }

  deleteRoom(roomId: number | undefined) {
    if (roomId !== undefined) {
      this.roomService.deleteRoom(roomId);
      this.rooms = this.roomService.getAllRooms();
    }
  }
  

  getAllRooms(): Room[] {
    return this.rooms;
  }

  filterByAvailability(available: boolean): void {
    this.rooms = this.roomService.getAllRooms().filter(room => room.available === available);
  }

  resetForm(): void {
    this.roomForm.reset();
  }
  
}