import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'

import { registerLocaleData } from '@angular/common'
import localePt from '@angular/common/locales/pt'
registerLocaleData(localePt, 'pt-BR')

import { AppComponent } from './app.component'
import { CardModule } from 'primeng/card'
import { ButtonModule } from 'primeng/button'
import { DropdownModule } from 'primeng/dropdown'
import { InputTextareaModule } from 'primeng/inputtextarea'
import { ToastModule } from 'primeng/toast'
import { TableModule } from 'primeng/table'
import { FileUploadModule } from 'primeng/fileupload'

import { CnabService } from './services/cnab.service'
import { CurrencyPipe } from './pipes/currency.pipe'

@NgModule({
    declarations: [AppComponent, CurrencyPipe],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpClientModule,
        CardModule,
        ButtonModule,
        DropdownModule,
        InputTextareaModule,
        ToastModule,
        TableModule,
        FileUploadModule
    ],
    providers: [ToastModule, CnabService],
    bootstrap: [AppComponent]
})
export class AppModule {}
