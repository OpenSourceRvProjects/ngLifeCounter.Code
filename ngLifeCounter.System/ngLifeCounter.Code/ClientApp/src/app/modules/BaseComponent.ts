import { LocalStorageService } from "../Services/Storage/local-storage.service";

export class BaseComponent {

    constructor(private localStorageService : LocalStorageService){
        this.localStorageService.desactivateCounterView();
    }
}

