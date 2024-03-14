'use server';

import { createEmployee, deleteEmployee, editEmployee } from '@/lib/services';
import { formSchema } from '@/lib/validation';
import { revalidatePath } from 'next/cache';
import { ZodError, z } from 'zod';

export type State =
  | {
    status: "success";
    message: string;
  }
  | {
    status: "error";
    message: string;
    errors?: Array<{
      path: string;
      message: string;
    }>;
  }
  | null;


export async function saveEmployee(prevState: State | null, data: FormData): Promise<State> {

  try {

    // Validate our data
    const { id, firstName, lastName, email, jobTitle, dateOfJoining } = formSchema.parse(data);

    if (id) {
      editEmployee({ id, firstName, lastName, email, jobTitle, dateOfJoining })
    } else {
      createEmployee({ firstName, lastName, email, jobTitle, dateOfJoining })
    }

    revalidatePath('/');

    return {
      status: "success",
      message: `Welcome, ${firstName} ${lastName ? lastName : ""}!`,
    };
  } catch (e) {
    console.error(e);
    // In case of a ZodError (caused by our validation) we're adding issues to our response
    if (e instanceof ZodError) {
      return {
        status: "error",
        message: "Invalid form data",
        errors: e.issues.map((issue) => ({
          path: issue.path.join("."),
          message: `Server validation: ${issue.message}`,
        })),
      };
    }
    return {
      status: "error",
      message: "Something went wrong. Please try again.",
    };
  }
}

export async function deleteEmployeeAction(id: string) {
  deleteEmployee(id)

  revalidatePath('/');
}
