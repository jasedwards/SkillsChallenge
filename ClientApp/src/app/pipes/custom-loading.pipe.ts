import { Pipe, PipeTransform } from '@angular/core';
import { catchError, isObservable, map, Observable, of, startWith } from 'rxjs';

@Pipe({
  name: 'customLoading',
  standalone: true
})
export class CustomLoadingPipe implements PipeTransform {

  transform(val: Observable<any>) {
    return isObservable(val)
      ? val.pipe(        
        map((value: any) => ({ loading: false, value: value } as any)),
        startWith({ loading: true } as any),
        catchError(error => of({ loading: false, error: 'Error Occured' } as any))
      )
      : val;
  }

}
