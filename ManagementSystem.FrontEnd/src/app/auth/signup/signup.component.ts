import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { UsersDto } from 'src/proxy/interfaces/users-dto';
import { UserService } from 'src/proxy/services/user-service.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {
  valCheck: string[] = ['remember'];

  role: string[] = ['Sysadmin', 'Manager']

    newUser : UsersDto ={
      name: '',
      username: '',
      email: '',
      password: '',
      phonenumber: '',
      address: '',
      city: '',
      role: '',
    }
    password!: string;

    constructor(
      public layoutService: LayoutService,
      public userService: UserService
      ) { }

    save(){
      this.userService.create(this.newUser)
      .subscribe((res) => {
        console.log(res);
      });
    }
}
