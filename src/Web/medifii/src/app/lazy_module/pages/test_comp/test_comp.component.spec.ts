import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { TestComp } from './test_comp.component';

describe('TestComp', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        TestComp
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(TestComp);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'medifii'`, () => {
    const fixture = TestBed.createComponent(TestComp);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('medifii');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(TestComp);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.content span').textContent).toContain('medifii app is running!');
  });
});
