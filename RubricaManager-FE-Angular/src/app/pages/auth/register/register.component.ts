import { Component } from '@angular/core';
import { UserRegisterDTO } from 'src/app/models/user';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private auth: AuthService) { }

  user : UserRegisterDTO = new UserRegisterDTO();
  formRegister = new FormGroup(
    {
      username: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl(''),
      email: new FormControl(''),
      name: new FormControl(''),
      lastname: new FormControl('')
    });
    register(){
      this.auth.register(this.user).subscribe();
    }


}
