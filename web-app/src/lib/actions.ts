'use server';

import { deleteEmployee } from '@/lib/services';
import { revalidatePath } from 'next/cache';

export async function deleteEmployeeAction(id: string) {
  deleteEmployee(id)

  revalidatePath('/employees');
}