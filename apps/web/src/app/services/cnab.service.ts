import { Injectable } from '@angular/core'

import { environment } from './../../environments/environment'
import { CnabModel } from '../models/cnab.model'

@Injectable()
export class CnabService {
    async getAllCnab() {
        const result = await fetch(environment.cnabApiUrl)
        const resultJson = await result.json()
        return <CnabModel[]>resultJson
    }
}
