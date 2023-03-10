import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorsComponent } from './core/test-errors/test-errors.component';
import { HomeComponent } from './home/home/home.component';
import { PageNotFoundComponent } from './shared/Components/page-not-found/page-not-found.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  { path: '', component: HomeComponent, data: { breadcrumb: 'Home' } },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'notFound', component: NotFoundComponent },
  { path: 'serverError', component: ServerErrorComponent },
  // Lazy Loading
  { path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule) },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
