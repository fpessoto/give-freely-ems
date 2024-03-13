import { ColumnDef } from '@tanstack/react-table';
import { Button } from '@/components/ui/button';
import { Employee } from '@/types/employee';

import {
  DotsHorizontalIcon,
  Pencil1Icon,
  TrashIcon,
} from '@radix-ui/react-icons';
import { Checkbox } from '@/components/ui/checkbox';
import { deleteEmployee } from '@/lib/actions';
import Link from 'next/link';

export function DeleteEmployee({ id }: { id: string }) {
  const deleteInvoiceWithId = deleteEmployee.bind(null, id);

  return (
    <form action={deleteInvoiceWithId}>
      <button className="rounded-md border p-2 hover:bg-gray-100">
        <span className="sr-only">Delete</span>
        <TrashIcon className="w-4" />
      </button>
    </form>
  );
}

export function EditEmployee({ id }: { id: string }) {
  return (
    <Button
      variant="link"
      type="button"
      className="rounded-md border p-2 hover:bg-gray-100"
    >
      <Link href={`/employees/${id}`} prefetch={false}>
        <span className="sr-only">Edit</span>
        <Pencil1Icon className="w-4" />
      </Link>
    </Button>
  );
}

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
    cell: ({ row }) => <div>{row.getValue('dateOfJoining')}</div>,
  },
  {
    accessorKey: 'totalYearsOfService',
    header: 'Years Of Service',
    cell: ({ row }) => (
      <div>
        {(row.getValue('totalYearsOfService') as number) < 1
          ? '< 1'
          : row.getValue('totalYearsOfService')}
      </div>
    ),
  },
  {
    id: 'actions',
    enableHiding: false,
    cell: ({ row }) => {
      const employee = row.original;

      return (
        <div className="flex flex-row space-x-2">
          <EditEmployee id={employee.id} />
          <DeleteEmployee id={employee.id} />
        </div>
      );
    },
  },
];
