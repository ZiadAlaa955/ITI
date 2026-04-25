import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Signup } from './pages/signup/signup';
import { Layout } from './layouts/layout/layout';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: Layout,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },
      {
        path: 'home',
        loadComponent: () => import('./pages/home/home').then((m) => m.Home),
      },
      {
        path: 'add',
        loadComponent: () => import('./pages/input/input').then((i) => i.InputForm),
      },
      {
        path: 'lists',
        loadComponent: () => import('./pages/taskList/taskList').then((l) => l.TaskList),
      },
    ],
  },
  {
    path: 'login',
    component: Login,
  },
  {
    path: 'signup',
    component: Signup,
  },
  {
    path: '**',
    loadComponent: () => import('./pages/notfound/notfound').then((n) => n.Notfound),
  },
];
