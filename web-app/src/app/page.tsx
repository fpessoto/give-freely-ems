import { getEmployees } from '@/lib/services';
import EmployeeList from './components/EmployeeList/EmployeeList';

export default async function EmployeePage() {
  const data = await getEmployees();

  return (
    <>
      <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Employees
      </h1>

      <EmployeeList employees={data} />
    </>
  );
}
