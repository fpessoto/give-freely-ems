import {
  flexRender,
  Table as TableType,
} from '@tanstack/react-table';
import { Button } from '@/components/ui/button';

import { Employee } from '@/types/employee';
import { columns } from './ColumsDataTable';
import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table,
} from '@/components/ui/table';

export default function EmployeesTable({
  employees,
}: {
  employees: Employee[];
}) {
  console.log('table', employees?.length);
  return (
    <div className="w-full">
      <div className="rounded-md border">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead className="w-[100px]">Id</TableHead>
              <TableHead>First Name</TableHead>
              <TableHead>Last Name</TableHead>
              <TableHead>Email</TableHead>
              <TableHead>JobTitle</TableHead>
              <TableHead>Date of Joining</TableHead>
              <TableHead>Years of Service</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {employees?.map((employee) => (
              <TableRow key={employee.id}>
                <TableCell className="font-medium">
                  {employee.id}
                </TableCell>
                <TableCell>{employee.firstName}</TableCell>
                <TableCell>{employee.lastName}</TableCell>
                <TableCell>{employee.email}</TableCell>
                <TableCell>{employee.jobTitle}</TableCell>
                {/* <TableCell>{employee.dateOfJoining}</TableCell> */}
                <TableCell>{employee.yearsOfService}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}
