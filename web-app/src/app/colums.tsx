import { ColumnDef } from '@tanstack/react-table';
import { Employee } from './employee/components/EmployeeList/EmployeeDataTable'; // Assuming the Employee type is defined in Employees.tsx

export const columns: ColumnDef<Employee>[] = [
  {
    accessorKey: 'firstName',
    header: 'First Name',
  },
  {
    accessorKey: 'lastName',
    header: 'Last Name',
  },
  {
    accessorKey: 'email',
    header: 'Email',
  },
  {
    accessorKey: 'jobTitle',
    header: 'Job Title',
  },
  {
    accessorKey: 'dateOfJoining',
    header: 'Date of Joining',
    // Optionally, you can provide a custom cell renderer for date formatting
    // renderCell: (cellValue: Date) => cellValue.toISOString().split('T')[0],
  },
  {
    accessorKey: 'YearsOfService',
    header: 'Years of Service',
  },
];
