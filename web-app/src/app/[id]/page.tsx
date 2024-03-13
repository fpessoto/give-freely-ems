import EmployeeForm from '@/app/components/EmployeeForm/EmployeeForm';
import { getEmployee } from '@/lib/services';

export default async function EditEmployee({
  params,
}: {
  params: { id: string };
}) {
  const id = params.id;
  const employee = await getEmployee(id);

  return (
    <>
      <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Edit
      </h1>

      <EmployeeForm existentEmployee={employee} />
    </>
  );
}
