import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivrariaAppComponent } from './livraria-app.component';

describe('LivrariaAppComponent', () => {
  let component: LivrariaAppComponent;
  let fixture: ComponentFixture<LivrariaAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivrariaAppComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LivrariaAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
