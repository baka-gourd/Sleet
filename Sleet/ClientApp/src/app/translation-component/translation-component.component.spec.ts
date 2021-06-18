import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslationComponentComponent } from './translation-component.component';

describe('TranslationComponentComponent', () => {
  let component: TranslationComponentComponent;
  let fixture: ComponentFixture<TranslationComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranslationComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TranslationComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
