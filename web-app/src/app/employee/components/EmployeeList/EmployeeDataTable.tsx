'use client';

import React, { useState } from 'react';
import {
  ColumnFiltersState,
  SortingState,
  VisibilityState,
  flexRender,
  getCoreRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useReactTable,
} from '@tanstack/react-table';

import { Button } from '@/components/ui/button';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import { columns } from './ColumsDataTable';
import { mockEmployees } from '@/data/fake-employees';
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuCheckboxItem,
} from '@radix-ui/react-dropdown-menu';
import { ChevronDownIcon, PlusIcon } from '@radix-ui/react-icons';
import { Input } from '../../../../components/ui/input';
import EmployeesTable from './EmployeesTable';

function ColumnsMenuDropDown(props: { getAllColumns: () => any[] }) {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="outline" className="ml-auto">
          Columns <ChevronDownIcon className="ml-2 h-4 w-4" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        {props
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

function EmployeesTableOptions({ table }) {
  const addEmployee = () => {
    console.log('Adding new employee');
  };

  return (
    <div className="flex items-center py-4">
      <Input
        placeholder="Filter emails..."
        value={
          (table.getColumn('email')?.getFilterValue() as string) ?? ''
        }
        onChange={(event) =>
          table.getColumn('email')?.setFilterValue(event.target.value)
        }
        className="max-w-sm"
      />
      <ColumnsMenuDropDown
        getAllColumns={table.getAllColumns}
      ></ColumnsMenuDropDown>

      <Button
        variant="outline"
        className="ml-auto"
        onClick={addEmployee}
      >
        New <PlusIcon className="ml-2 h-4 w-4" />
      </Button>
    </div>
  );
}

export default function EmployeesDataTable() {
  const [sorting, setSorting] = useState<SortingState>([]);
  const [columnFilters, setColumnFilters] =
    useState<ColumnFiltersState>([]);
  const [columnVisibility, setColumnVisibility] =
    useState<VisibilityState>({});
  const [rowSelection, setRowSelection] = useState({});

  const table = useReactTable({
    data: mockEmployees,
    columns,
    onSortingChange: setSorting,
    onColumnFiltersChange: setColumnFilters,
    getCoreRowModel: getCoreRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
    onColumnVisibilityChange: setColumnVisibility,
    onRowSelectionChange: setRowSelection,
    state: {
      sorting,
      columnFilters,
      columnVisibility,
      rowSelection,
    },
  });

  return (
    <>
      <EmployeesTableOptions table={table}></EmployeesTableOptions>

      <EmployeesTable table={table} />
    </>
  );
}
