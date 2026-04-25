import { Component, inject } from '@angular/core';
import { NotificationService } from '../../services/notificationService';

@Component({
  selector: 'app-notification',
  imports: [],
  templateUrl: './notification.html',
  styleUrl: './notification.css',
})
export class Notification {
  ns = inject(NotificationService);
}
