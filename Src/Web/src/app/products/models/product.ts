export class Product {
    private id: number;
    private name: string;
    private description: string;
    private price: number;
    private expiryDate: Date;
    private quantity: number;
    private deliveryOptions: string;
    private availability: string;
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
