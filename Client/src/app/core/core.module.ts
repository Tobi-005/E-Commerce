import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AppRoutingModule } from '../app-routing.module';
import { TestsErrorComponent } from './tests-error/tests-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';



@NgModule({
  declarations: [NavBarComponent, TestsErrorComponent, NotFoundComponent, ServerErrorComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    ToastrModule.forRoot({
      positionClass : 'toast-bottom-right',
      preventDuplicates: true

    })
  ],
  exports: [
    NavBarComponent
  ]
})
export class CoreModule { }
