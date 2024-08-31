import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Student } from '../models/student.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public students: Student[] = [];
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<Student[]>(baseUrl + 'students').subscribe({
      next: (result) => {
        this.students = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  deleteStudent(student: Student): void {
    const studentName = `${student?.firstName} ${student?.lastName}`
    const confirmed = confirm(`Are you sure you want to delete the student named ${studentName}?`);
    if (confirmed) {
      this.http.delete(this.baseUrl + 'students', { body: student }).subscribe({
        next: () => {
          const newStudentList = this.students.filter(s => s.email !== student.email);
          this.students = newStudentList;
        },
        error: (error) => {
          console.error('An error occurred while deleting the student.', error);
        }
      });
    }
  }

  getGradeStyle(grade: number): { [key: string]: string } {
    let backgroundColor: string;

    if (grade >= 80) {
      backgroundColor = '#a6e1a6';
    } else if (grade >= 50) {
      backgroundColor = '#ffecb3';
    } else {
      backgroundColor = '#f5c6cb';
    }

    return {
      'background-color': backgroundColor
    };
  }

  ngOnInit() {}
}
