export class Product {
    public id: number;
    public name: string;
    public description: string;
    public price: number;
    public expiryDate: Date;
    public quantity: number;
    public deliveryOptions: string;
    public availability: string;
    constructor(name: string, price: number, expiryDate: Date, quantity: number, deliveryOptions: string, availability: string, id?: number, description?: string) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.expiryDate = expiryDate;
        this.quantity = quantity;
        this.deliveryOptions = deliveryOptions;
        this.availability = availability;
    }
}
