import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { HomeService, HomeResponse } from './home.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  private readonly homeService = inject(HomeService);

  data?: HomeResponse;

  ngOnInit(): void {
    this.homeService.getHome().subscribe(response => {
      this.data = response;
    });
  }
}
