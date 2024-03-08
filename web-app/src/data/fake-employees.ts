import { Employee } from '../types/employee';

export const mockEmployees: Employee[] = [
  {
    id: '1',
    firstName: 'John',
    lastName: 'Doe',
    email: 'john.doe@example.com',
    jobTitle: 'Software Engineer',
    dateOfJoining: new Date('2020-01-15'),
  },
  {
    id: '2',
    firstName: 'Jane',
    lastName: 'Smith',
    email: 'jane.smith@example.com',
    jobTitle: 'Product Manager',
    dateOfJoining: new Date('2019-05-20'),
  },
  // Add more mock employee data as needed
];