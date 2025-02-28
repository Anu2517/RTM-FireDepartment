import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

// Import NgZorro Modules
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { EChartsOption } from 'echarts';
import { NgxEchartsModule, NGX_ECHARTS_CONFIG } from 'ngx-echarts';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    NzCardModule,  // ✅ Import Card module
    NzGridModule,
    NgxEchartsModule   // ✅ Import Grid module
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  providers: [
    {
      provide: NGX_ECHARTS_CONFIG,
      useValue: { echarts: () => import('echarts') }
    }
  ]
})
export class DashboardComponent {
  totalApplications = 120;
  pendingInspections = 8;
  openComplaints = 5;
  resolvedComplaints = 3;
  applicationGrowth = "+5%";
  lastInspectionUpdate = "2 hours ago";

  approvedApplications = 95;
  rejectedApplications = 10;
  ongoingReviews = 12;

  recentUpdates = [
    "New application submitted",
    "Inspection scheduled for tomorrow",
    "Complaint resolved",
    "System update applied"
  ];


  pieChartOptions: EChartsOption = {
    title: {
      text: 'Application Status Distribution',
      left: 'center',
      textStyle: { color: '#fff' }
    },
    tooltip: { trigger: 'item' },
    legend: {
      bottom: '0%',
      textStyle: { color: '#fff' }
    },
    series: [
      {
        name: 'Applications',
        type: 'pie',
        radius: '55%',
        data: [
          { value: this.approvedApplications, name: 'Approved', itemStyle: { color: '#28a745' } },
          { value: this.rejectedApplications, name: 'Rejected', itemStyle: { color: '#ff4d4f' } },
          { value: this.ongoingReviews, name: 'Ongoing', itemStyle: { color: '#17a2b8' } }
        ],
        label: { color: '#fff' }
      }
    ]
  };
}
