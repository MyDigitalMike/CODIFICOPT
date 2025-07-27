import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CustomerService } from '../../../services/customer.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { Pipe, PipeTransform } from '@angular/core';
@Component({
  selector: 'app-new-order-modal',
  standalone: false,

  templateUrl: './new-order-modal.component.html',
  styleUrl: './new-order-modal.component.css'
})
export class NewOrderModalComponent implements OnInit {
  orderForm: FormGroup;
  employees: any[] = [];
  shippers: any[] = [];
  products: any[] = [];

  selectedEmployee: number | null = null;
  selectedShipper: number | null = null;
  selectedProduct: number | null = null;


  constructor(public activeModal: NgbActiveModal, private customerService: CustomerService, private fb: FormBuilder) {
    this.orderForm = this.fb.group({
      empId: [0, Validators.required],
      shipperId: [0, Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      orderDate: [new Date().toISOString(), Validators.required],
      requiredDate: [new Date().toISOString(), Validators.required],
      shippedDate: [new Date().toISOString(), Validators.required],
      freight: [0, [Validators.required, Validators.min(0)]],
      shipCountry: ['', Validators.required],
      orderDetails: this.fb.array([
        this.fb.group({
          productId: [null, Validators.required],
          unitPrice: [null, Validators.required],
          qty: [null, Validators.required],
          discount: [0],
        }),
      ]),
    });
  }
  get orderDetails() {
    return this.orderForm.get('orderDetails') as FormArray;
  }
  ngOnInit(): void {
    this.loadEmployees();
    this.loadShippers();
    this.loadProducts();
  }
  loadEmployees(): void {
    this.customerService.getEmployees().subscribe({
      next: (data) => {
        this.employees = data;
      },
      error: (err) => console.error('Error loading employees', err),
    });
  }
  loadShippers(): void {
    this.customerService.getShippers().subscribe({
      next: (data) => {
        this.shippers = data;
      },
      error: (err) => console.error('Error loading shippers', err),
    });
  }
  loadProducts(): void {
    this.customerService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: (err) => console.error('Error loading products', err),
    });
  }
  onSubmit(): void {
    if (this.orderForm.valid) {
      console.log('Formulario enviado:', this.orderForm.value);
      this.customerService.postOrder(this.orderForm.value).subscribe({
        next: () => {
          Swal.fire({
            title: 'Order Submitted!',
            text: 'The order has been submitted successfully.',
            icon: 'success',
            confirmButtonText: 'OK'
          });
          this.orderForm.reset();
          this.activeModal.close();
        },
        error: (err) => console.error('Error al enviar la orden', err),
      });
    } else {
      console.log('Formulario no válido');
      this.orderForm.markAllAsTouched();
    }
  }

}





