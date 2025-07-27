import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { OrderDto } from '../../../services/api/models';
import { CustomerService } from '../../../services/customer.service';

@Component({
  selector: 'app-orders-modal',
  standalone: false,

  templateUrl: './orders-modal.component.html',
  styleUrl: './orders-modal.component.css'
})
export class OrdersModalComponent implements OnInit {
  @Input() custId!: number;
  columns = [
    { field: 'orderId', header: 'Order ID' },
    { field: 'requiredDate', header: 'Required Date' },
    { field: 'shippedDate', header: 'Shipped Date' },
    { field: 'shipName', header: 'Ship Name' },
    { field: 'shipAddress', header: 'Ship Address' },
    { field: 'shipCity', header: 'Ship City' },
  ];
  orders: OrderDto[] = [];
  constructor(public activeModal: NgbActiveModal, private customerService: CustomerService) { }
  ngOnInit(): void {
    this.getOrdersById();
  }
  getOrdersById(): void {
    this.customerService.getCustomerOrders(this.custId).subscribe({
      next: (data) => {
        this.orders = data;
      },
      error: (err) => console.error('Error al cargar ordenes', err),
    });
  }
}
