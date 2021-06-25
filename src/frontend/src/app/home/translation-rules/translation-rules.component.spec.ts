import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslationRulesComponent } from './translation-rules.component';

describe('TranslationRulesComponent', () => {
  let component: TranslationRulesComponent;
  let fixture: ComponentFixture<TranslationRulesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranslationRulesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TranslationRulesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
