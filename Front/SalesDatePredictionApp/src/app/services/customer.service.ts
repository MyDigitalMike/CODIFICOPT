import { Injectable } from '@angular/core';
import { CustomerPredictionService } from './api/services';
import { CustomerPredictionDto, EmployeeDto, OrderDto, ShipperDto, ProductDto } from './api/models';
import { Observable } from 'rxjs';
import { OrderService } from './api/services';
import { EmployeeService } from './api/services';
import { ShipperService } from './api/services';
import { ProductService } from './api/services';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private custumerPredictionApi: CustomerPredictionService,
    private orderService: OrderService,
    private employeeService: EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService ) { }
  /**
  * Método para buscar clientes por nombre
  * @param customerName Nombre del cliente (puede ser vacío o null para obtener todos)
  * @returns Observable<CustomerPredictionDto[]>
  */
  searchCustomers(customerName: string): Observable<CustomerPredictionDto[]> {
    return this.custumerPredictionApi.apiCustomerPredictionGet$Json({
      customerName,
    });
  }
  getCustomerOrders(customerId: number): Observable<OrderDto[]> {
    return this.orderService.apiOrderCustomerIdOrdersGet$Json({
      customerId,
    });
  }
  getEmployees(): Observable<EmployeeDto[]> {
    return this.employeeService.apiEmployeeGet$Json();
  }
  getShippers(): Observable<ShipperDto[]> {
    return this.shipperService.apiShipperGet$Json();
  }
  getProducts(): Observable<ProductDto[]> {
    return this.productService.apiProductGet$Json();
  }
  postOrder(order: OrderDto): Observable<OrderDto[]> {
    return this.orderService.apiOrderPost$Json({
      body: order,
    });
  }
}
