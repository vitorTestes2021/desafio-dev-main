import { Component, OnInit, ViewChild } from '@angular/core'

import { PrimeNGConfig, MessageService } from 'primeng/api'

import { environment } from './../environments/environment'

import { CnabService } from './services/cnab.service'
import { CnabModel } from './models/cnab.model'

interface Store {
    id: number
    name: string
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [MessageService]
})
export class AppComponent implements OnInit {
    constructor(
        private primengConfig: PrimeNGConfig,
        private messageService: MessageService,
        private cnabService: CnabService
    ) {}

    stores: Store[] = []
    selectedStore: Store = {} as any
    cnabs: CnabModel[] = []
    total: number = 0
    cnabApiUrl: string = ''
    @ViewChild('fileUpload') fileUpload: any

    async ngOnInit(): Promise<void> {
        this.primengConfig.ripple = true
        this.cnabApiUrl = environment.cnabApiUrl
        await this.loadAllCnabs()
    }

    private async loadAllCnabs() {
        this.cnabs = []
        try {
            this.cnabs = await this.cnabService.getAllCnab()
            this.loadAllStores()
            this.refreshTable()
        } catch (error) {
            this.messageService.add({
                key: 'bc',
                severity: 'warning',
                summary: 'Houve um problema ao carregar os cnabs'
            })
        }
    }

    private loadAllStores() {
        this.cnabs.forEach((cnab: CnabModel) => {
            const result = this.stores.filter(
                (st) => cnab.nameStore === st.name
            )
            if (!result.length) {
                this.stores.push({
                    id: cnab.id,
                    name: cnab.nameStore
                })
            }
        })
        this.stores = this.sortStores()
        this.selectedStore = this.stores[0]
    }

    private sortStores(): Store[] {
        return this.stores.sort((a, b) => {
            if (a.name < b.name) {
                return -1
            }
            if (a.name > b.name) {
                return 1
            }
            return 0
        })
    }

    public refreshTable() {
        this.total = 0
        this.cnabs.forEach((cnab) => {
            cnab.visible = this.selectedStore.name === cnab.nameStore
            this.total += cnab.visible ? cnab.value : 0
        })
    }

    public showUploading() {
        this.messageService.add({
            key: 'bc',
            severity: 'info',
            summary: 'Enviando o arquivo!'
        })
    }

    public async showUploaded() {
        this.messageService.add({
            key: 'bc',
            severity: 'success',
            summary: 'Enviado com sucesso!'
        })
        await this.loadAllCnabs()
    }

    public showUploadError(event: any) {
        let errorMessage = 'Houve um erro ao enviar o arquivo'
        if (event.error) {
            errorMessage = event.error.error
        }
        this.messageService.add({
            key: 'bc',
            severity: 'error',
            summary: errorMessage
        })
        this.fileUpload.clear()
    }
}
