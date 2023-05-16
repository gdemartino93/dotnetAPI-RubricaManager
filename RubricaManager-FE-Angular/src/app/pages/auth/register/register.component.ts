import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private auth: AuthService, private fb : FormBuilder) { }
  form! : FormGroup;

  ngOnInit(): void {
    this.form = this.fb.group({
      'username' : ['',Validators.required],
      'password' : ['',Validators.required],
      'confirmPassword' : ['',Validators.required],
      'email' : ['',Validators.required],
      'name' : [''],
      'lastname' : ['']
    });
  }
  onPost(){
    console.log(this.form.value);
  }
  // user : RegisterRequest = new UserRegisterDTO();
  // formRegister = new FormGroup(
  //   {
  //     username: new FormControl(''),
  //     password: new FormControl(''),
  //     confirmPassword: new FormControl(''),
  //     email: new FormControl(''),
  //     name: new FormControl(''),
  //     lastname: new FormControl('')
  //   });
  //   register(){
  //     this.auth.register(this.user).subscribe();
  //   }


}
