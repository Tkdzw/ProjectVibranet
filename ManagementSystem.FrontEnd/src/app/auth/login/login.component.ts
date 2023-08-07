import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  signupUsers: any[] = [];
  signupObj: any = {
    userName: '',
    email:'',
    password: ''
  }


  ngOnInit(): void {
    const localData = localStorage.getItem('signUpUsers');
    if(localData !=null) {
      this.signupUsers = JSON.parse(localData);
    }
  }

  loginObj: any = {
    userName: '',
    password: ''
  }

  onSignup(){
    this.signupUsers.push(this.signupObj);
    localStorage.setItem('signUpUsers', JSON.stringify(this.signupUsers));
    this.signupObj = {
      userName: '',
      email:'',
      password: ''
    }
  }

  onLogin(){
    const isUserExist = this.signupUsers.find(m => m.userName == this.loginObj.userName && m.password ==this.loginObj.password);
    if(isUserExist != undefined) {
      alert('User Login Successfuly')
    }else{
      alert('Wrong Credentials');
    }
  }
}
