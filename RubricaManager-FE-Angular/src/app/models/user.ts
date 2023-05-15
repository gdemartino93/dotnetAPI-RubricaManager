export class User{
  username: string = "";
  email? : string;
  name? : string;
  lastname? : string;
}

export class UserRegisterDTO{
  username : string = "";
  password : string = "";
  confirmPassword : string = "";
  email : string = "";
  name? : string;
  lastname? : string;
}

export class UserLoginDTO{
  username : string = "";
  password : string = "";
}
