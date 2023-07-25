import { Component, OnInit } from '@angular/core';
import { UserPositionService }  from '../../services/user-position.service';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-user-position',
  templateUrl: './user-position.component.html',
  styleUrls: ['./user-position.component.css']
})
export class UserPositionComponent implements OnInit {
  userPosition: any;
  loading: boolean = true;

  showXAxis = true;
  showYAxis = true;
  showLegend = false;
  showXAxisLabel = true;
  showYAxisLabel = true;
  xAxisLabel = 'Ativo';
  yAxisLabel = 'Quantidade';

  chartData: any[]=[];

  constructor(private userPositionService: UserPositionService) { }

  ngOnInit(): void {
    this.userPositionService.getUserPosition().subscribe(
      (data) => {
        this.userPosition = data;
        this.prepareChartData();
        this.loading = false;
      },
      (error) => {
        console.error('Erro:', error);
        this.loading = false;
      }
    );
  }

  prepareChartData(): void {
    this.chartData = this.userPosition.positions.map((asset:any) => {
      return {
        name: asset.symbol,
        value: asset.amount
      };
    });
  }
}
