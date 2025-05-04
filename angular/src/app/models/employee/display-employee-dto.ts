export class DisplayEmployeeDto {
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public email: string,
        public position: string,
        public departmentId: number
    ){}
}
