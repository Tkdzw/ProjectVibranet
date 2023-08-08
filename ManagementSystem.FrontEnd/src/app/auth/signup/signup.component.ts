import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { UsersDto } from 'src/proxy/interfaces/users-dto';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {
  valCheck: string[] = ['remember'];

  role: string[] = ['Role1', 'Role2']

    user : UsersDto ={
      firstname:'',
      email:'',
      password:'',
      role:'',
    }
    password!: string;

    constructor(public layoutService: LayoutService) { }

    save(){
      
    }
}
