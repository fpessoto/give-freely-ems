'use server';

import { formSchema } from '@/app/employees/components/EmployeeForm/EmployeeForm';
import { toast } from '@/components/ui/use-toast';
import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';
import { z } from 'zod';

const CreateEmployee = formSchema;

export async function deleteEmployee(id: string) {
  try {
    const url = `http://localhost/Employees/${id}`;
    const response = await fetch(url, {
      method: 'DELETE',
    });

  } catch (error) {
    console.error(error);
  }

  revalidatePath('/employees');
}


export async function createEmployee(values: z.infer<typeof formSchema>) {

  // const values = CreateEmployee.parse({
  //   firstName: formData.get('firstName'),
  //   lastName: formData.get('lastName'),
  //   email: formData.get('email'),
  //   jobTitle: formData.get('jobTitle'),
  //   dateOfJoining: formData.get('dateOfJoining'),
  // });

  console.log('createEmployee', values);

  try {
    const response = await fetch('http://localhost/Employees', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json', // Content type
      },
      body: JSON.stringify(values),
    });

    if (!response.ok) {
      toast({
        description: 'Unable to add the employee',
      });
      return;
    }

    toast({
      description: 'Employee added with success',
    });

    revalidatePath('/employees');
    redirect('/employees');
  } catch (error) {
    console.error(error);
  }

  // console.log(values);
}