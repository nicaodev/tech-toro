import { Component, OnInit } from '@angular/core';
import { UserPositionService } from '../../services/user-position.service';

@Component({
  selector: 'app-user-position',
  templateUrl: './user-position.component.html',
  styleUrls: ['./user-position.component.css']
})
export class UserPositionComponent implements OnInit {
  userPosition: any; // You can create an interface for this too, matching the returned JSON structure
  loading: boolean = true;

  constructor(private userPositionService: UserPositionService) { }

  ngOnInit(): void {
    this.userPositionService.getUserPosition().subscribe(
      (data) => {
        this.userPosition = data;
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching user position:', error);
        this.loading = false;
      }
    );
  }
}
