import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Student } from '../models/student.model';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  public studentForm: FormGroup;
  public message: string | null = null;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      major: ['', Validators.required],
      averageGrade: ['', Validators.required],
    });
  }

  public onSubmit(): void {
    this.studentForm.markAllAsTouched();
    
    if (this.studentForm.valid) {
      const newStudent: Student = this.studentForm.value;

      this.http.post<{ success: boolean; message: string; student?: Student }>(this.baseUrl + 'students', newStudent)
        .subscribe({
          next: (response) => {
            console.log(response);
            this.message = 'Student added successfully!';
            this.studentForm.reset();
          },
          error: (error) => {
            console.error('Error:', error);
            this.message = 'An error occurred while adding the student.';
          },
        });
    }
  }
}
