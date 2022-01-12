export class CustomerProfile {
    customerId: number;
    customerName: string;
    customerPhone: string;
    customerEmail: string;
    customerAddress: string;
    customerMailingAddress: string;

    constructor(customerId: number,
        customerName: string,
        customerPhone: string,
        customerEmail: string,
        customerAddress: string,
        customerMailingAddress: string,
        ) {
        this.customerId = customerId;
        this.customerName = customerName;
        this.customerPhone = customerPhone;
        this.customerEmail = customerEmail;
        this.customerAddress = customerAddress;
        this.customerMailingAddress = customerMailingAddress;
    }
}
