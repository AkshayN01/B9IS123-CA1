import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-room-assignment-dialog',
  templateUrl: './room-assignment-dialog.component.html',
  styleUrls: ['./room-assignment-dialog.component.css']
})
export class RoomAssignmentDialogComponent implements OnInit {
  selectedRoomId: number = 0;
  availableRooms: any[] = [];

   constructor(
    public dialogRef: MatDialogRef<RoomAssignmentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }
  ngOnInit(): void {
    this.availableRooms = [
      { id: 1, roomNumber: 101, roomType: { id: 1, name: "Single Room", price: 50 } },
      { id: 2, roomNumber: 102, roomType: { id: 2, name: "Double Room", price: 80 } },
      { id: 3, roomNumber: 103, roomType: { id: 1, name: "Single Room", price: 50 } }
     
    ];
  }

  saveRoomAssignment() {
    this.dialogRef.close(this.selectedRoomId);
  }

  cancel() {
    this.dialogRef.close();
  }
}
