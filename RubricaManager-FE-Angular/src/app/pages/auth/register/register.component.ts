import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private auth: AuthService,
               private fb : FormBuilder,
               private router :Router) { }
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
  register() {
    this.auth.register(this.form.value).subscribe(
      response => {
        console.log("Registrazione avvenuta con successo", response);
        this.router.navigate(['']);

      },
      error => {
        console.error("Errore durante la registrazione", error);


      }
    );
  }




}
