import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { OrdersModalComponent } from '../../features/orders-modal/orders-modal.component';
import { NewOrderModalComponent } from '../../features/new-order-modal/new-order-modal.component';
@Component({
  selector: 'app-dynamic-table-component',
  standalone: false,

  templateUrl: './dynamic-table-component.component.html',
  styleUrl: './dynamic-table-component.component.css'
})
export class DynamicTableComponentComponent implements OnInit {
  @Input() columns: { field: string; header: string }[] = [];
  @Input() data: any[] = [];
  @Input() searchEnabled: boolean = false;
  @Input() hasButtons: boolean = false;
  @Output() search: EventEmitter<string> = new EventEmitter<string>();
  @Output() pageChange: EventEmitter<number> = new EventEmitter<number>();

  searchTerm: string = '';
  displayedData: any[] = [];
  filteredData: any[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 10;
  totalPages: number = 0;
  sortColumn: string | null = null;
  sortDirection: 'asc' | 'desc' | null = null;

  constructor(private modalService: NgbModal) { }
  openOrdersModal(custId: any): void {
    const modalRef = this.modalService.open(OrdersModalComponent, {
      size: 'xl'
    });
    modalRef.componentInstance.custId = custId;
  }
  openNewOrderModal(): void {
    const modalRef = this.modalService.open(NewOrderModalComponent, {
      size: 'md'
    });
  }
  ngOnInit(): void {
    this.filteredData = [...this.data];
    this.updateTable();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['data']) {
      this.filteredData = [...this.data];
      this.updateTable();
    }
  }

  onSearch(): void {
    if (this.searchTerm) {
      this.filteredData = this.data.filter((row) =>
        Object.values(row).some((value) =>
          String(value).toLowerCase().includes(this.searchTerm.toLowerCase())
        )
      );
    } else {
      this.filteredData = [...this.data];
    }
    this.currentPage = 1;
    this.updateTable();
    this.search.emit(this.searchTerm);
  }

  sortData(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    const direction = this.sortDirection === 'asc' ? 1 : -1;
    this.filteredData.sort((a, b) =>
      a[column] > b[column] ? direction : a[column] < b[column] ? -direction : 0
    );

    this.updateTable();
  }

  changePage(page: number): void {
    if (page > 0 && page <= this.totalPages) {
      this.currentPage = page;
      this.updateTable();
      this.pageChange.emit(this.currentPage);
    }
  }

  private updateTable(): void {
    this.totalPages = Math.ceil(this.filteredData.length / this.itemsPerPage);
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.displayedData = this.filteredData.slice(startIndex, endIndex);
  }
  onItemsPerPageChange(): void {
    this.currentPage = 1;
    this.updateTable();
  }
  getStartIndex(): number {
    return (this.currentPage - 1) * this.itemsPerPage;
  }

  getEndIndex(): number {
    const end = this.getStartIndex() + this.itemsPerPage;
    return end > this.filteredData.length ? this.filteredData.length : end;
  }
  handleItemsPerPageChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.itemsPerPage = parseInt(target.value, 10);
    this.currentPage = 1;
    this.updateTable();
  }
}
