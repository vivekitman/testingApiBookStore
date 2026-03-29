import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface HomeResponse {
  title: string;
  vision: string;
  mission: string;
  chairmanMessage: string;
  lastUpdatedUtc: string;
  banners: { heading: string; subHeading: string; imageUrl: string }[];
  announcements: { id: number; title: string; category: string; linkUrl: string; publishDateUtc: string; isImportant: boolean }[];
  quickLinks: { label: string; url: string }[];
}

@Injectable({ providedIn: 'root' })
export class HomeService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = 'https://localhost:7216/api';

  getHome(): Observable<HomeResponse> {
    return this.http.get<HomeResponse>(`${this.baseUrl}/public/home`);
  }
}
