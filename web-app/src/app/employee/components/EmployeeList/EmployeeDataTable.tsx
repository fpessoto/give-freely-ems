'use client';

import { useState } from 'react';
import {
  ColumnFiltersState,
  SortingState,
  VisibilityState,
  getCoreRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useReactTable,
} from '@tanstack/react-table';
import { columns } from './ColumsDataTable';
import EmployeesTable from './EmployeesTable';
import EmployeesTableOptions from './EmployeesTableOptions';
import { Employee } from '@/types/employee';

type EmployeeDataTableProps = {
  employees: Employee[];
};

export default function EmployeesDataTable({
  employees,
}: EmployeeDataTableProps) {
  const [sorting, setSorting] = useState<SortingState>([]);
  const [columnFilters, setColumnFilters] =
    useState<ColumnFiltersState>([]);
  const [columnVisibility, setColumnVisibility] =
    useState<VisibilityState>({});
  const [rowSelection, setRowSelection] = useState({});

  console.log('dattable', employees);

  const table = useReactTable({
    data: employees,
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
