import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerPanelComponent } from './dealer-panel.component';

describe('DealerPanelComponent', () => {
  let component: DealerPanelComponent;
  let fixture: ComponentFixture<DealerPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DealerPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DealerPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
