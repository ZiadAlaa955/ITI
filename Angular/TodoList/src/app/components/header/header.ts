import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.html',
  imports: [RouterLink, RouterLinkActive],
  styleUrl: './header.css',
})
export class Header implements OnInit, OnDestroy {
  router = inject(Router);
  seconds: number = 0;
  timer: any;
  username: string = '';

  ngOnInit() {
    this.timer = setInterval(() => {
      this.seconds++;
    }, 1000);

    const userString = localStorage.getItem('activeUser');
    if (userString) {
      const activeUser = JSON.parse(userString);
      this.username = activeUser.username;
    }
  }

  logout() {
    localStorage.removeItem('activeUser');
    this.router.navigate(['/login']);
  }

  ngOnDestroy() {
    clearInterval(this.timer);
  }
}
