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
    this.selectedRoom = null;
  }

  openAddRoomForm(): void {
    this.showAddRoomForm = true;
  }

  addRoom(): void {
    const newRoom: Room = this.roomForm.value;
    this.roomService.addRoom(newRoom);
    this.resetForm();
    this.rooms = this.roomService.getAvailableRooms();
    this.showAddRoomForm = false;
  }

  cancelAddRoom(): void {
    this.resetForm();
    this.showAddRoomForm = false;
  }

  updateRoom(room: Room | null): void {
    if (room !== null) {
      this.selectedRoom = { ...room };
    }
  }
  cancelUpdate(): void {
    this.selectedRoom = null;
  }

  deleteRoom(roomId: number | undefined): void {
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