export class DisplayEmployeeDto {
    constructor(
        public id: number,
        public fullName: string,
        public email: string,
        public position: string,
        public departmentId: number
    ){}
}
