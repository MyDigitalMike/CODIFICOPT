import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerRoutingModule } from './costumer-routing.module';
import { CustomersComponent } from './customers/customers.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrdersModalComponent } from './orders-modal/orders-modal.component';
import { NewOrderModalComponent } from './new-order-modal/new-order-modal.component';
import { NgSelectModule } from '@ng-select/ng-select';
@NgModule({
  declarations: [
    CustomersComponent,
    OrdersModalComponent,
    NewOrderModalComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule
  ]
})
export class CustomerModule {}
