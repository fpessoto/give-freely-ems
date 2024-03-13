import EmployeesDataTable from './components/EmployeeList/EmployeeDataTable';
import { Employee } from '@/types/employee';

export const getEmployees = async () => {
  // Fetch data from external API
  const res = await fetch('http://localhost/Employees', {
    next: { tags: ['get-employees'] },
  });
  const data: { employees: Employee[] } = await res.json();
  return data.employees;
};

export default async function EmployeePage() {
  const data = await getEmployees();

  return (
    <>
      <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Employees
      </h1>

      <EmployeesDataTable employees={data} />
    </>
  );
}
