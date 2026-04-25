import { Component, EventEmitter, inject, Input, OnDestroy, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Task } from '../../types';
import { TaskService } from '../../services/task-service';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-taskCard',
  templateUrl: './taskCard.html',
  styleUrl: './taskCard.css',
  imports: [FormsModule, NgClass],
})
export class TaskCard implements OnDestroy {
  taskService = inject(TaskService);
  @Input() taskInfo!: Task;

  @Output() deleteTask = new EventEmitter<string>();

  deleteTaskFromList() {
    this.deleteTask.emit(this.taskInfo.id);
  }

  @Output() updateTaskEvent = new EventEmitter<Task>();

  triggerUpdate() {
    this.updateTaskEvent.emit({ ...this.taskInfo });
  }

  toggleStatus() {
    this.taskService.toggleDoneStatus(this.taskInfo.id!, this.taskInfo.done!).subscribe();
  }

  ngOnDestroy(): void {
    console.log(`This task has been removed: ${this.taskInfo.title}`);
  }
}
