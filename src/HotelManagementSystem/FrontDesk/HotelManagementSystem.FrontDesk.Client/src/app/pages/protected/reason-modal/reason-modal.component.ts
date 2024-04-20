import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-reason-modal',
  templateUrl: './reason-modal.component.html',
  styleUrls: ['./reason-modal.component.css']
})
export class ReasonModalComponent {
  reason: string = '';

  constructor(
    public dialogRef: MatDialogRef<ReasonModalComponent>,
    public activeModal: NgbActiveModal,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.reason = ''; 
  }

  cancel(): void {
    this.dialogRef.close(this.reason);
  }

  submitReason(): void {
    this.dialogRef.close(this.reason);
  }
}