import { Component, input  } from "@angular/core";
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-reason-modal',
    templateUrl: './reason-modal.component.html',
    })

export class ReasonModalComponent {
    @input() bookingId: number=0;
    reason: string='';

    constructor(public activeModal: NgbActiveModal) {
        this.bookingId = 0;
    }

    submitReason(): void {
        this.activeModal.class(this.reason);
    }
}   
@NgModule({
    declarations: [
      ReasonModalComponent
    ],
    imports: [
      FormsModule // Add FormsModule here
    ],
    providers: [],
    bootstrap: [ReasonModalComponent]
  })