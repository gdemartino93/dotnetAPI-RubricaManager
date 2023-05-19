import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewcontactComponent } from './addnewcontact.component';

describe('AddnewcontactComponent', () => {
  let component: AddnewcontactComponent;
  let fixture: ComponentFixture<AddnewcontactComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddnewcontactComponent]
    });
    fixture = TestBed.createComponent(AddnewcontactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
