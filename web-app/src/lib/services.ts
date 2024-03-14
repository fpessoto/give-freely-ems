import { Employee } from '@/types/employee';

const BASE_URL = process.env.API_URL;

export async function deleteEmployee(id: string) {
  try {

    const url = `${BASE_URL}/Employees/${id}`;
    const response = await fetch(url, {
      method: 'DELETE',
    });

    if (!response.ok) {
      throw new Error('Error trying to delete employee');
    }
  } catch (error) {
    console.error(error);
    throw error;
  }
}

export const getEmployee = async (id: string) => {
  const res = await fetch(`${BASE_URL}/Employees/${id}`);
  const data: Employee = await res.json();
  return data;
};

export const getEmployees = async () => {

  try {
    // Fetch data from external API
    const res = await fetch(`${BASE_URL}/Employees`, {
      next: { tags: ['get-employees'] },
    });
    const data: { employees: Employee[] } = await res.json();
    return data.employees;
  } catch (error) {
    throw error;
  }

};

export const createEmployee = async (data: {
  firstName: string;
  lastName: string;
  email: string;
  jobTitle: string;
  dateOfJoining: string;
}) => {
  const response = await fetch(`${BASE_URL}/Employees`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json', // Content type
    },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error('Fail create Employee');
  }
}

export const editEmployee = async (data: {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  jobTitle: string;
  dateOfJoining: string;

}) => {
  const response = await fetch(`${BASE_URL}/Employees/${data.id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json', // Content type
    },
    body: JSON.stringify(data),
  });

  if (!response.ok) {
    throw new Error('Fail edit Employee');
  }
}

