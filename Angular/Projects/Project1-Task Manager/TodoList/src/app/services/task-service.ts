import { inject, Injectable } from '@angular/core';
import { Task } from '../types';
import { generateShortId } from '../helper';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  http = inject(HttpClient);
  baseURL = 'http://localhost:3000/tasks';

  private getActiveUserId(): string {
    const activeUserStr = localStorage.getItem('activeUser');
    if (activeUserStr) {
      const activeUser = JSON.parse(activeUserStr);
      return activeUser.id;
    }
    return '';
  }

  getAllTasks() {
    const currentUserId = this.getActiveUserId();

    return this.http.get<Task[]>(this.baseURL, {
      params: { userId: currentUserId },
    });
  }

  addTask(newtask: Task) {
    newtask.id = generateShortId();
    newtask.done = false;

    newtask.userId = this.getActiveUserId();

    return this.http.post<Task>(this.baseURL, newtask);
  }

  updateTask(updatedTask: Task) {
    return this.http.put(`${this.baseURL}/${updatedTask.id}`, updatedTask);
  }

  deleteTask(id: string) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  toggleDoneStatus(id: string, status: boolean) {
    return this.http.patch(`${this.baseURL}/${id}`, { done: status });
  }
}
