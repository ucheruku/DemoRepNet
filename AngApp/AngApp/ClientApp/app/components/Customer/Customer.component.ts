import { Component, Inject  } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: "Customer",
    templateUrl: './Customer.component.html'
})

export class CustomerDataComponent {

    public Customers:Customer[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/DataService/GetCustomers').subscribe(result => {
            this.Customers = result.json() as Customer[];
        }, error => console.error(error));
    }

    
}

interface Customer {
    id: number,
    firstName: string,
    lastLName :string
}
