import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserPositionComponent } from './user/user-position/user-position.component';

const routes: Routes = [{
  path: "", component: UserPositionComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
