import { Component, inject, OnInit } from '@angular/core';
import { StudentsService } from '../services/students.service';
import { Observable } from 'rxjs';
import { Student } from '../types/student';
import { AsyncPipe, TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [AsyncPipe,TitleCasePipe],
  templateUrl: './students.component.html',
  styleUrl: './students.component.css'
})
export class StudentsComponent implements OnInit{
  
  students$!:Observable<Student[]>
  studentsService = inject(StudentsService)

  ngOnInit(): void {
    this.students$ = this.studentsService.getStudents()
    
  }
}
