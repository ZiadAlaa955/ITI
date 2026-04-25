import { Injectable } from '@angular/core';
import { NotificationType } from '../types';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  message: string = '';
  type: NotificationType = null;
  private timeoutTimer: any;

  show(message: string, type: NotificationType) {
    this.message = message;
    this.type = type;

    if (this.timeoutTimer) {
      clearTimeout(this.timeoutTimer);
    }

    this.timeoutTimer = setTimeout(() => {
      this.clear();
    }, 3000);
  }

  clear() {
    this.message = '';
    this.type = null;
  }
}
