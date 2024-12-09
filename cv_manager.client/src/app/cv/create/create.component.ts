import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CVCreateComponent {
  cvForm: FormGroup;
  submissionError: string = '';

  constructor(private fb: FormBuilder, private apiService: ApiService, private router: Router) {
    this.cvForm = this.fb.group({
      name: ['', [Validators.required]],
      personalInformationDto: this.fb.group({
        fullName: ['', [Validators.required, Validators.maxLength(100)]],
        cityName: [''],
        email: ['', [Validators.required, Validators.email]],
        mobileNumber: ['', [Validators.required, Validators.pattern('^[0-9]+$'), Validators.maxLength(15)]]
      }),
      experienceInformationDto: this.fb.group({
        companyName: ['', [Validators.required, Validators.maxLength(100)]],
        City: [''],
        CompanyField: ['']
      })
    });
  }

  ngOnInit(): void { }

  get name(): AbstractControl | null { return this.cvForm.get('name'); }
  get personalInformation(): FormGroup { return this.cvForm.get('personalInformationDto') as FormGroup; }
  get experienceInformation(): FormGroup { return this.cvForm.get('experienceInformationDto') as FormGroup; }


  onSubmit(): void {
    if (this.cvForm.valid) {
      const createCVDto = this.cvForm.value;

      this.apiService.post('cv', createCVDto).subscribe({
        next: (response) => {
          console.log('CV Created:', response);
          this.router.navigate(['/cv']);
        },
        error: (error) => {
          console.error('Error creating CV:', error);
          this.submissionError = 'An error occurred while creating the CV. Please try again.';
        }
      });
    } else {
      this.cvForm.markAllAsTouched(); // Trigger validation messages
    }
  }

}
