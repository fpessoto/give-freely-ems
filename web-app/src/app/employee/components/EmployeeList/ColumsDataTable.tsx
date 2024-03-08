import { ColumnDef } from '@tanstack/react-table';
import { Button } from '@/components/ui/button';
import { Employee } from '@/types/employee';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { DotsHorizontalIcon } from '@radix-ui/react-icons';
import { Checkbox } from '@/components/ui/checkbox';

export const columns: ColumnDef<Employee>[] = [
  {
    id: 'select',
    header: ({ table }) => (
      <Checkbox
        checked={
          table.getIsAllPageRowsSelected() ||
          (table.getIsSomePageRowsSelected() && 'indeterminate')
        }
        onCheckedChange={(value) =>
          table.toggleAllPageRowsSelected(!!value)
        }
        aria-label="Select all"
      />
    ),
    cell: ({ row }) => (
      <Checkbox
        checked={row.getIsSelected()}
        onCheckedChange={(value) => row.toggleSelected(!!value)}
        aria-label="Select row"
      />
    ),
    enableSorting: false,
    enableHiding: false,
  },
  {
    accessorKey: 'id',
    header: 'Id',
    cell: ({ row }) => (
      <div className="capitalize">{row.getValue('id')}</div>
    ),
  },
  {
    accessorKey: 'firstName',
    header: 'First Name',
    cell: ({ row }) => (
      <div className="capitalize">{row.getValue('firstName')}</div>
    ),
  },
  {
    accessorKey: 'lastName',
    header: 'Last Name',
    cell: ({ row }) => (
      <div className="capitalize">{row.getValue('lastName')}</div>
    ),
  },
  {
    accessorKey: 'email',
    header: 'Email',
    cell: ({ row }) => (
      <div className="lowercase">{row.getValue('email')}</div>
    ),
  },
  {
    accessorKey: 'jobTitle',
    header: 'Job Title',
    cell: ({ row }) => (
      <div className="capitalize">{row.getValue('jobTitle')}</div>
    ),
  },
  {
    accessorKey: 'dateOfJoining',
    header: 'Date of Joining',
    cell: ({ row }) => (
      <div>
        {(row.getValue('dateOfJoining') as Date).toLocaleDateString()}
      </div>
    ),
  },
  {
    accessorKey: 'yearsOfService',
    header: 'Years Of Service',
    cell: ({ row }) => (
      <div className="capitalize">
        {(row.getValue('yearsOfService') as number) < 1
          ? '< 1'
          : row.getValue('yearsOfService')}
      </div>
    ),
  },
  {
    id: 'actions',
    enableHiding: false,
    cell: ({ row }) => {
      const employee = row.original;

      return (
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" className="h-8 w-8 p-0">
              <span className="sr-only">Open menu</span>
              <DotsHorizontalIcon className="h-4 w-4" />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuLabel>Actions</DropdownMenuLabel>
            <DropdownMenuItem
              onClick={() => deleteEmployee(employee.id)}
            >
              Delete
            </DropdownMenuItem>
            <DropdownMenuItem
              onClick={() => updateEmployee(employee.id)}
            >
              Edit
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      );
    },
  },
];

const updateEmployee = (employeeId: string) => {
  console.log('editing employee', employeeId);
};

const deleteEmployee = (employeeId: string) => {
  console.log('deleting employee', employeeId);
};
