import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private auth : AuthService) { }
  // user: UserLoginDTO = new UserLoginDTO();

  formLogin = new FormGroup(
    {
      username: new FormControl(''),
      password: new FormControl('')
    }
  );

  // login(UserLoginDTO: UserLoginDTO){
  //   this.auth.login(UserLoginDTO).subscribe((token) => {
  //     localStorage.setItem('token', token.result.token);
  //     console.log(localStorage.getItem('token'));
  //   })
  // }
}
