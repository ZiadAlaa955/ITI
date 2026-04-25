import { Component, EventEmitter, Input, Output } from '@angular/core';
import { tab } from '../../types';

@Component({
  selector: 'app-tabs',
  imports: [],
  templateUrl: './tabs.html',
  styleUrl: './tabs.css',
})
export class Tabs {
  @Input() activeTab!: tab;

  @Output() tabChanged = new EventEmitter<tab>();

  changeTab(tabName: string) {
    this.tabChanged.emit(tabName as tab);
  }
}
