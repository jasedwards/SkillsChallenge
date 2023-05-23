import { ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent } from '../table/table.component';
import { PeopleService } from './people.service';
import { TableData } from '../table-data';
import { QuickSearchDirective } from '../quick-search.directive';
import { BehaviorSubject, debounceTime, distinctUntilChanged, Observable, of, switchMap } from 'rxjs';
import { CustomLoadingPipe } from '../pipes/custom-loading.pipe';

@Component({
  selector: 'app-people',
  standalone: true,
  imports: [CommonModule, TableComponent, QuickSearchDirective, CustomLoadingPipe],
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent {
  searchStream$ = new BehaviorSubject('');
  obs$ = this.searchStream$.pipe(
    debounceTime(200),
    distinctUntilChanged(),
    switchMap((query) => this.service.fetch(query))
  );
  readonly columns: TableData[] = [
    {
      Header: 'First Name',
      PropName: 'firstName'
    },
    {
      Header: 'Last Name',
      PropName: 'lastName'
    },
    {
      Header: 'Birthday',
      PropName: 'birthday'
    }
  ];

  constructor(private service: PeopleService, private cd: ChangeDetectorRef) {

  }

}
