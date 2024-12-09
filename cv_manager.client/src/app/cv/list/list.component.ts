import { Component } from '@angular/core';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class CVListComponent {

  cvs: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadCVs();
  }

  loadCVs(): void {
    this.apiService.get('cv').subscribe((data: any) => {
      this.cvs = data;
    });
  }

  delete(id: number): void {
    this.apiService.delete(`cv/${id}`).subscribe(() => {
      this.loadCVs();
    })
  }

}
