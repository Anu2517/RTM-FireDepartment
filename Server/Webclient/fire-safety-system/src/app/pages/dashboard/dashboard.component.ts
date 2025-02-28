import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

// Import NgZorro Modules
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    NzCardModule,  // ✅ Import Card module
    NzGridModule   // ✅ Import Grid module
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
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
}
