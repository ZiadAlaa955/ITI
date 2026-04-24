import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Notification } from './components/notification/notification';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [RouterOutlet, Notification],
})
export class App {}
