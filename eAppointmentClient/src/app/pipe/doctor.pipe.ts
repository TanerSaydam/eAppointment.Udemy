import { Pipe, PipeTransform } from '@angular/core';
import { DoctorModel } from '../models/doctor.model';

@Pipe({
  name: 'doctor',
  standalone: true
})
export class DoctorPipe implements PipeTransform {

  transform(value: DoctorModel[], search: string): DoctorModel[] {
    if(!search){
      return value;
    }

    return value.filter(p=>
      p.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.department.name.toLocaleLowerCase().includes(search.toLocaleLowerCase())
    )
  }

}
