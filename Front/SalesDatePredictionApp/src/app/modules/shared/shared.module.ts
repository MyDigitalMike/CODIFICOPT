import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DynamicTableComponentComponent } from './dynamic-table-component/dynamic-table-component.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faArrowUp, faArrowDown } from '@fortawesome/free-solid-svg-icons';
import { NgSelectModule } from '@ng-select/ng-select';
@NgModule({
  declarations: [DynamicTableComponentComponent],
  imports: [CommonModule,FormsModule,FontAwesomeModule, NgSelectModule],
  exports: [DynamicTableComponentComponent]
})
export class SharedModule {
  constructor() {
    library.add(faArrowUp, faArrowDown);
  }
}
