import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogoutCompletedComponent } from './logout-completed.component';

describe('LogoutCompletedComponent', () => {
  let component: LogoutCompletedComponent;
  let fixture: ComponentFixture<LogoutCompletedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LogoutCompletedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LogoutCompletedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
