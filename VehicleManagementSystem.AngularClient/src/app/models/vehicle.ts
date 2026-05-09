export interface Vehicle {
  id: number;
  brand: string;
  model: string;
  year: number;
  registrationNumber: string;
  color: string;
  mileage: number;
  fuelType: string;
  price: number;
  isAvailable: boolean;
  imageUrl: string;
  createdAt: string;
  updatedAt?: string;
}