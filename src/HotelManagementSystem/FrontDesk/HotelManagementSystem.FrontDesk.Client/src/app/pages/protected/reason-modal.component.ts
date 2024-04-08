import { Component, input  } from "@angular/core";
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-reason-modal',
    templateUrl: './reason-modal.component.html',
})
expect class ReasonModalComponent {
    @Input() bookingId: number;
    reason: string;

    constructor(public activeModal: NgbActiveModal) {}

    submitReason(): void {
        this.activeModal.class(this.reason);
    }
}