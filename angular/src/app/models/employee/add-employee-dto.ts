export class AddEmployeeDto {
    constructor(
        public firstName: string,
        public lastName: string,
        public email: string,
        public position: string,
        public departmentId?: number| null
    ){}
}
