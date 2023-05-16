export interface RegisterRequest{
  username : string;
  password : string;
  confirmPassword : string;
  email : string;
  name? : string;
  lastname? : string;
}

export interface LoginRequest{
  username : string;
  password : string;
}

export interface LoginResponse{
  token : string;
  role : string;
  username : string;

}
