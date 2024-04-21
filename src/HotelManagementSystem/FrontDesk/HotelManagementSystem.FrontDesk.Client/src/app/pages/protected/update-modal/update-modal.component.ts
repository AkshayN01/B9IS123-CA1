import { Component } from '@angular/core';

@Component({
  selector: 'app-update-modal',
  templateUrl: './update-modal.component.html',
  styleUrl: './update-modal.component.css'
})
export class UpdateModalComponent {

constructor(
  public dialogRef: MatDialogRef<UpdateRoomModalComponent>,
  @Inject(MAT_DIALOG_DATA) public data: Room
) {}

onNoClick(): void {
  this.dialogRef.close();
}
}