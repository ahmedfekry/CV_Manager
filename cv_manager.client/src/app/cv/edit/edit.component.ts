import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class CVEditComponent {
  editForm!: FormGroup;
  cvId!: number;

  constructor(private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    // Get the CV ID from the route
    this.cvId = +this.route.snapshot.paramMap.get('id')!;

    // Initialize the form
    this.editForm = this.fb.group({
      name: ['', [Validators.required]],
      personalInformationDto: this.fb.group({
        fullName: ['', [Validators.required]],
        cityName: [''],
        email: ['', [Validators.email]],
        mobileNumber: [
          '',
          [Validators.required, Validators.pattern(/^\d+$/)],
        ],
      }),
      experienceInformationDto: this.fb.group({
        companyName: ['', [Validators.required]],
        companyField: [''],
      }),
    });

    this.apiService.getDetails('cv', this.cvId).subscribe({
      next: (cv: any) => {
        this.editForm.patchValue({
          name: cv.name,
          personalInformationDto: {
            fullName: cv.personalInformationDto.fullName,
            email: cv.personalInformationDto.email,
            mobileNumber: cv.personalInformationDto.mobileNumber,
          },
          experienceInformationDto: {
            companyName: cv.experienceInformationDto.companyName,
            companyField: cv.experienceInformationDto.companyField,
          },
        });
      },
      error: (err) => {
        console.error('Error fetching CV:', err);
      },
    });
  }

  onSubmit(): void {
    if (this.editForm.valid) {
      this.apiService.put('cv', this.editForm.value, this.cvId).subscribe(() => {
        alert('CV updated successfully');
        this.router.navigate(['/cv']);
      });
    }
  }
}
