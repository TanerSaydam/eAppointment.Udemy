import { Pipe, PipeTransform } from '@angular/core';
import { UserModel } from '../models/user.model';

@Pipe({
  name: 'user',
  standalone: true
})
export class UserPipe implements PipeTransform {

  transform(value: UserModel[], search: string): UserModel[] {
    if(!search){
      return value;
    }

    return value.filter(p=>
      p.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.userName.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.email.toLocaleLowerCase().includes(search.toLocaleLowerCase())
    );
  }

}
