'use client';

import { Button } from '@/components/ui/button';
import Link from 'next/link';
import { Employee } from '@/types/employee';
import { Table as TableType } from '@tanstack/react-table';
import { Input } from '@/components/ui/input';

export default function EmployeesTableOptions({
  table,
}: {
  table: TableType<Employee>;
}) {
  return (
    <div className="flex flex-row items-center py-4 space-x-4">
      <Input
        placeholder="Filter First Name..."
        value={
          (table
            .getColumn('firstName')
            ?.getFilterValue() as string) ?? ''
        }
        onChange={(event) =>
          table
            .getColumn('firstName')
            ?.setFilterValue(event.target.value)
        }
        className="max-w-sm"
      />
      <Input
        placeholder="Filter Last Name..."
        value={
          (table.getColumn('lastName')?.getFilterValue() as string) ??
          ''
        }
        onChange={(event) =>
          table
            .getColumn('lastName')
            ?.setFilterValue(event.target.value)
        }
        className="max-w-sm"
      />
      <Input
        placeholder="Filter Job Title..."
        value={
          (table.getColumn('jobTitle')?.getFilterValue() as string) ??
          ''
        }
        onChange={(event) =>
          table
            .getColumn('jobTitle')
            ?.setFilterValue(event.target.value)
        }
        className="max-w-sm"
      />

      <Button variant="default" className="ml-auto" type="button">
        <Link href="/add">Add</Link>
      </Button>
    </div>
  );
}
