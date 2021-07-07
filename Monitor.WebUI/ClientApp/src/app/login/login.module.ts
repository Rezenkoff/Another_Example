import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { LoginService } from "./services/login.service";
import { LoginComponent } from "./components/login.component";

@NgModule({
    declarations: [
        LoginComponent,
    ],
    imports: [
        HttpClientModule,
        FormsModule,
        CommonModule,
        RouterModule.forChild([
            { path: '', component: LoginComponent },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: '' },
        ]),
    ],
    providers: [LoginService],
})
export class LoginModule { }
