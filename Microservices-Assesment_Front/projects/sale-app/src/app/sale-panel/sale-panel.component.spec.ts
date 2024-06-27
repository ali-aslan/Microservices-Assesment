import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalePanelComponent } from './sale-panel.component';

describe('SalePanelComponent', () => {
  let component: SalePanelComponent;
  let fixture: ComponentFixture<SalePanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalePanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalePanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
