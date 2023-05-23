import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent } from '../table/table.component';
import { TableData } from '../table-data';
import { ThingsService } from './things.service';
import { QuickSearchDirective } from '../quick-search.directive';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-things',
  standalone: true,
  imports: [CommonModule, TableComponent, QuickSearchDirective],
  templateUrl: './things.component.html',
  styleUrls: ['./things.component.css']
})
export class ThingsComponent implements OnInit {
  serviceobservable$: Subject<void> = new Subject<void>();
  isLoading = true;
  rows!: { [key: string]: any }[];
  readonly columns: TableData[] = [
    {
      Header: 'Name',
      PropName: 'description'
    },
    {
      Header: 'Description',
      PropName: 'name'
    }
  ];

  constructor(private service: ThingsService, private cd: ChangeDetectorRef) {

  }

  ngOnInit() {
    this.search();
  }

  search(filter = '') {
    this.service.fetch(filter).pipe(takeUntil(this.serviceobservable$)).subscribe(value => {
      this.rows = value;
      this.isLoading = false;
      this.cd.detectChanges();
    });
  }

  ngOnDestroy(): void {
    this.serviceobservable$.next();
    this.serviceobservable$.complete();
  }
}
