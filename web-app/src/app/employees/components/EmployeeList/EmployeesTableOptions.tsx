'use client';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuCheckboxItem,
} from '@radix-ui/react-dropdown-menu';
import { ChevronDownIcon } from '@radix-ui/react-icons';
import { Input } from '../../../../components/ui/input';
import router from 'next/router';
import Link from 'next/link';
import { Employee } from '@/types/employee';
import { Table as TableType } from '@tanstack/react-table';

function ColumnsMenuDropDown({
  table,
}: {
  table: TableType<Employee>;
}) {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="outline" className="ml-auto">
          Columns <ChevronDownIcon className="ml-2 h-4 w-4" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        {table
          .getAllColumns()
          .filter((column) => column.getCanHide())
          .map((column) => {
            return (
              <DropdownMenuCheckboxItem
                key={column.id}
                className="capitalize"
                checked={column.getIsVisible()}
                onCheckedChange={(value) =>
                  column.toggleVisibility(!!value)
                }
              >
                {column.id}
              </DropdownMenuCheckboxItem>
            );
          })}
      </DropdownMenuContent>
    </DropdownMenu>
  );
}

export default function EmployeesTableOptions({
  table,
}: {
  table: TableType<Employee>;
}) {
  const addEmployee = () => {
    console.log('Adding new employee');
    router.push('/add');
  };

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
      <ColumnsMenuDropDown table={table}></ColumnsMenuDropDown>

      <Button variant="default" className="ml-auto" type="button">
        <Link href="/employees/add">Add</Link>
      </Button>
    </div>
  );
}
