import { Component, inject, OnInit } from '@angular/core';
import { TaskCard } from '../../components/taskCard/taskCard';
import { tab, Task } from '../../types';
import { Tabs } from '../../components/tabs/tabs';
import { TaskService } from '../../services/task-service';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/notificationService';

@Component({
  selector: 'app-taskList',
  templateUrl: './taskList.html',
  styleUrl: './taskList.css',
  imports: [TaskCard, Tabs],
})
export class TaskList implements OnInit {
  taskService = inject(TaskService);
  router = inject(Router);
  activeTab: tab = 'All';
  taskList: Task[] = [];

  loadTasks() {
    this.taskService.getAllTasks().subscribe((data) => {
      this.taskList = data;
    });
  }

  ngOnInit() {
    this.loadTasks();
  }

  notify = inject(NotificationService);

  deleteTask(taskId: string) {
    this.taskService.deleteTask(taskId).subscribe(() => {
      this.taskList = this.taskList.filter((task) => task.id !== taskId);

      this.notify.show('Task deleted!', 'error');
    });
  }

  sendEditRequest(taskToEdit: Task) {
    this.router.navigate(['/add'], { state: { task: taskToEdit } });
  }
}
