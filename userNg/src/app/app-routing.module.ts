import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuctionItemsComponent } from './pages/auction-items/auction-items.component';
import { AuctionItemComponent } from './pages/auction-item/auction-item.component';
import { AuctionChatComponent } from './pages/auction-chat/auction-chat.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ConfirmEmailComponent } from './pages/confirm-email/confirm-email.component';
import { CheckTransactionComponent } from './pages/check-transaction/check-transaction.component';
import { SuccessTransactionComponent } from './pages/success-transaction/success-transaction.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/items' },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'items', component: AuctionItemsComponent },
  { path: 'item', component: AuctionItemComponent },
  { path: 'item/:id', component: AuctionItemComponent },
  { path: 'chat/:id', component: AuctionChatComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'profile/:id', component: ProfileComponent },
  { path: 'login/confirm', component: ConfirmEmailComponent },
  { path: 'checkTransaction', component: CheckTransactionComponent },
  { path: 'successTransaction', component: SuccessTransactionComponent },
  { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
