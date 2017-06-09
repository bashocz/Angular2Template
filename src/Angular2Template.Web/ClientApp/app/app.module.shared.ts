import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { HeaderComponent } from './components/shared/header/header.component';
import { AccountListComponent } from './components/account/account-list/account-list.component';
import { AccountSummaryComponent } from './components/account/account-summary/account-summary.component';
import { AccountDetailComponent } from './components/account/account-detail/account-detail.component';
import { AccountActivityComponent } from './components/account/account-activity/account-activity.component';
import { AccountService } from './components/shared/account.service';
import { FormatAccountNumberPipe } from './components/shared/format-account-number.pipe';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        HeaderComponent,
        AccountListComponent,
        AccountDetailComponent,
        AccountSummaryComponent,
        AccountActivityComponent,
        FormatAccountNumberPipe
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'account', pathMatch: 'full' },
            { path: 'account', component: AccountListComponent },
            { path: 'detail/:id', component: AccountDetailComponent },
            { path: '**', redirectTo: 'account' }
        ])
    ],
    providers: [ AccountService ]
};
