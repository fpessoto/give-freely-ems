import { ChevronDownIcon, PlusIcon } from '@radix-ui/react-icons';
import { Button } from '../../components/ui/button';
import EmployeesDataTable from './components/EmployeeList/EmployeeDataTable';
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuCheckboxItem,
} from '@radix-ui/react-dropdown-menu';
import { table } from 'console';
import { Input } from 'postcss';
import {
  SortingState,
  ColumnFiltersState,
  VisibilityState,
  useReactTable,
  getCoreRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  getFilteredRowModel,
} from '@tanstack/react-table';
import { useState } from 'react';
import { columns } from '../colums';
import { Employee } from '../../types/employee';

const mockEmployees: Employee[] = [
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

const addEmployee = () => {
  // Implement logic to add a new employee
};

const updateEmployee = (employeeId: string) => {
  // Implement logic to update the employee with the given ID
};

const deleteEmployee = (employeeId: string) => {
  // Implement logic to delete the employee with the given ID
};

export default function EmployeePage() {
  return (
    <>
      <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Employees
      </h1>

      <EmployeesDataTable />
    </>
  );
}
