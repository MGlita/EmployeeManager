export class Employee {
    id: number;
    firstname: string;
    surname: string;
    gender: string;
    nationality: string;
    phoneNumber: string;
    birthDate: Date;
    email: string;
    department: number;
    hiredDate: Date = new Date(Date.now());
    salary: number = 9999;
    jobTitle: string = "Ninja"
    city: string = "Dębno"
    street: string = "Topolska"
    streetNo: string = "123"
    zipCode: string = "12-123"
}
