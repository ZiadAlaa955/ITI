import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-slider',
  imports: [],
  templateUrl: './slider.html',
  styleUrl: './slider.css',
})
export class Slider implements OnInit, OnDestroy {
  currentIndex: number = 0;
  images: string[] = [
    '/images/img1.jpg',
    '/images/img2.jpg',
    '/images/img3.jpg',
    '/images/img4.jpg',
  ];

  sliderTimer: any;
  ngOnInit() {
    this.AutoPlay();
  }

  ngOnDestroy() {
    clearInterval(this.sliderTimer);
  }

  AutoPlay() {
    this.sliderTimer = setInterval(() => {
      this.nextImage(this.currentIndex);
    }, 5000);
  }

  resetTimer() {
    clearInterval(this.sliderTimer);
    this.AutoPlay();
  }

  clickImage(index: number) {
    this.currentIndex = index;
    this.resetTimer();
  }

  nextImage(index: number) {
    if (index + 1 == this.images.length) {
      index = -1;
    }
    this.currentIndex = index + 1;
    this.resetTimer();
  }

  prevImage(index: number) {
    if (index - 1 == -1) {
      index = this.images.length;
    }
    this.currentIndex = index - 1;
    this.resetTimer();
  }
}
