import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../services/customer.service';
import { CustomerPredictionDto } from '../../../services/api/models';

@Component({
  selector: 'app-customers',
  standalone: false,
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {

  columns = [
    { field: 'customerName', header: 'Customer Name' },
    { field: 'lastOrderDate', header: 'Last Order Date' },
    { field: 'nextPredictedOrder', header: 'Next Predicted Order' }
  ];
  customers: CustomerPredictionDto[] = [];
  searchTerm: string = '';
  constructor(private customerService: CustomerService) { }
  ngOnInit(): void {
    this.getCustomers();
  }
  getCustomers(): void {
    this.customerService.searchCustomers(this.searchTerm).subscribe({
      next: (data) => {
        this.customers = data;
      },
      error: (err) => console.error('Error al cargar clientes', err),
    });
  }
  onSearch(): void {
    this.customerService.searchCustomers(this.searchTerm).subscribe((data) => {
      this.getCustomers();
    });
  }
}
