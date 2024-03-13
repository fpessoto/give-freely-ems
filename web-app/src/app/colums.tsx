import { Employee } from '@/types/employee';
import { ColumnDef } from '@tanstack/react-table';

export const columns: ColumnDef<Employee>[] = [
  {
    accessorKey: 'id',
    header: 'ID',
  },
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
