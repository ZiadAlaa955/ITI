import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Task } from '../../types';
import { TaskService } from '../../services/task-service';
import { Router } from '@angular/router';
import { NgClass } from '@angular/common';
import { NotificationService } from '../../services/notificationService';

@Component({
  selector: 'app-input',
  templateUrl: './input.html',
  styleUrl: './input.css',
  imports: [FormsModule, NgClass],
})
export class InputForm {
  taskService = inject(TaskService);
  router = inject(Router);
  editMode = false;
  task: Task = {
    title: '',
    description: '',
    priority: '',
    category: '',
    done: false,
    tag: '',
    date: '',
  };

  constructor() {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation?.extras.state as { task: Task };

    if (state && state.task) {
      this.task = { ...state.task };
      this.editMode = true;
    }
  }

  notify = inject(NotificationService);

  saveTask() {
    if (this.editMode) {
      this.taskService.updateTask(this.task).subscribe(() => {
        this.notify.show('Task updated successfully!', 'success');
        this.router.navigate(['/lists']);
      });
    } else {
      this.taskService.addTask(this.task).subscribe(() => {
        this.notify.show('New task added!', 'success');
        this.router.navigate(['/lists']);
      });
    }
  }
}
