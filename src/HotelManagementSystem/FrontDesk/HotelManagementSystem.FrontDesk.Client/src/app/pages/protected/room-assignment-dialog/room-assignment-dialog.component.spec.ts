import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomAssignmentDialogComponent } from './room-assignment-dialog.component';

describe('RoomAssignmentDialogComponent', () => {
  let component: RoomAssignmentDialogComponent;
  let fixture: ComponentFixture<RoomAssignmentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RoomAssignmentDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RoomAssignmentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
