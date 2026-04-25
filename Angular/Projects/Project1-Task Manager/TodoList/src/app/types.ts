export interface Task {
  id?: string;
  title: string;
  description: string;
  priority: string;
  category: string;
  done: boolean;
  tag: string;
  date: string;
  userId?: string;
}

export interface User {
  email: string;
  username: string;
  password: string;
}

export interface INotification {
  message: string;
  type: NotificationType;
}

export type NotificationType = 'success' | 'error' | 'warning' | 'info' | null;

export type priorityType = 'Low' | 'Medium' | 'High' | '';
export type categoryType = 'Work' | 'Personal' | 'Study' | '';

export type error = {
  message: string;
  state: boolean;
};

export type tab = 'All' | 'Done' | 'ToDo';
