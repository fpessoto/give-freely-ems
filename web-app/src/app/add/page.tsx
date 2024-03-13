import { z } from 'zod';

import EmployeeForm from '@/app/components/EmployeeForm/EmployeeForm';

export default function AddEmployee({}: {}) {
  return (
    <>
      <h1 className="scroll-m-20 text-4xl font-extrabold tracking-tight lg:text-5xl">
        Add new employee
      </h1>

      <EmployeeForm />
    </>
  );
}
