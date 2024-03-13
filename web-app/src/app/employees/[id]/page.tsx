import EmployeeForm from '@/app/employees/components/EmployeeForm/EmployeeForm';
import { Employee } from '@/types/employee';

export const getEmployees = async (id: string) => {
  // Fetch data from external API
  const res = await fetch(`http://localhost/Employees/${id}`, {});
  const data: Employee = await res.json();
  return data;
};

export default async function EditEmployee({
  params,
}: {
  params: { id: string };
}) {
  const id = params.id;
  const employee = await getEmployees(id);

  return (
    <>
      <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Edit
      </h1>

      <EmployeeForm existentEmployee={employee} />
    </>
  );
}
