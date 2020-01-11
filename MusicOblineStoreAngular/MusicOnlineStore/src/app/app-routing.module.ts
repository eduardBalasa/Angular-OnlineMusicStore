import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";
import { RegisterComponent } from "./register/register.component";
import { AuthGuard } from "./guards/auth.guards";
import { Role } from "./models/role";
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  { path: "", component: HomeComponent, canActivate: [AuthGuard] },

  {
    path: "admin",
    component: LoginComponent,
    canActivate: [AuthGuard],
    data: { roles: [Role.Admin] }
  },

  {
    path: "login",
    component: LoginComponent
  },

  {
    path: "home",
    component: HomeComponent
  },
  
  { path: "register", 
    component: RegisterComponent 
  },

  { path: "product/:productName", 
    component: ProductComponent },

  // otherwise redirect to home
  { path: "**", redirectTo: "" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
