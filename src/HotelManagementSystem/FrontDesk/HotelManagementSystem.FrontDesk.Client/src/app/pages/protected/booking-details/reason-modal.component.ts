import { Component, Input } from "@angular/core";
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-reason-modal',
    templateUrl: './reason-modal.component.html',
})
export class ReasonModalComponent {
    @Input() bookingId: number = 0;
    reason: string = '';

    constructor(public activeModal: NgbActiveModal) {}

    submitReason(): void {
        this.activeModal.close(this.reason);
    }
}