import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Room } from '../../../inter/room.interface';

@Component({
  selector: 'app-update-room',
  templateUrl: './update-room.component.html',
  styleUrls: ['./update-room.component.css']
})
export class UpdateRoomComponent {
  constructor(
    public dialogRef: MatDialogRef<UpdateRoomComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Room
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  updateRoomSubmit(): void {
    // Define logic to handle form submission (e.g., updating room details)
  }
}
