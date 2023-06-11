import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Ad {
  name: string;
  photoLink: string;
  price: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'ApiAdsFrontEnd';
  ads: Ad[] = []
  ad: Ad = {
    name: '',
    photoLink: '',
    price: 0
  };
  adById: Ad = {
    name: '',
    photoLink: '',
    price: 0
  };
  adGid: string = ''

  constructor(private http: HttpClient) { }

  onSubmit() {
    this.http.post('https://localhost:7226/AdsControllers/ad', this.ad)
      .subscribe(
      () => {
        this.ad = {
          name: '',
          photoLink: '',
          price: 0
        };
      },
      error => {
        console.error('Error submitting ad data:', error);
      }
    );
  }

  getAllAds() {
    this.http.get<Ad[]>('https://localhost:7226/AdsControllers/ads?sortBy=price&ascending=false&skip=0&take=10')
      .subscribe(
        ads => {
          this.ads = ads;
        },
        error => {
          console.error('Error fetching ads:', error);
        }
      );
  }

  getAdByGid() {
    this.http.get<Ad>(`https://localhost:7226/AdsControllers/gid?gid=${this.adGid}`)
      .subscribe(
        ads => {
          this.adById = {
            name: ads.name,
            price: ads.price,
            photoLink: ads.photoLink
          }
        },
        error => {
          console.error('Error fetching ads:', error);
        }
      );
  }
}
