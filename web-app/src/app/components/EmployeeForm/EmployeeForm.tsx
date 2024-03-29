'use client';

import { Button } from '@/components/ui/button';
import { Calendar } from '@/components/ui/calendar';
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover';
import { toast } from '@/components/ui/use-toast';
import { State, saveEmployee } from '@/lib/actions';
import { cn } from '@/lib/utils';
import { formSchema } from '@/lib/validation';
import { Employee } from '@/types/employee';
import { zodResolver } from '@hookform/resolvers/zod';
import { CalendarIcon } from '@radix-ui/react-icons';
import { format } from 'date-fns';
import Link from 'next/link';
import { useEffect, useState } from 'react';
import { useFormState } from 'react-dom';
import { FieldPath, useForm } from 'react-hook-form';
import { z } from 'zod';

type EmployeeFormProp = {
  existentEmployee?: Employee;
};

export interface FormValues {
  id?: string;
  firstName: string;
  lastName: string;
  email: string;
  jobTitle: string;
  dateOfJoining: string;
}

export default function EmployeeForm({
  existentEmployee,
}: EmployeeFormProp) {
  const [state, formAction] = useFormState<State, FormData>(
    saveEmployee,
    null
  );
  const [date, setDate] = useState(new Date().toISOString());

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      id: existentEmployee?.id ?? '',
      firstName: existentEmployee?.firstName ?? '',
      lastName: existentEmployee?.lastName ?? '',
      email: existentEmployee?.email ?? '',
      jobTitle: existentEmployee?.jobTitle ?? '',
      dateOfJoining: '2024-1-1',
    },
  });

  useEffect(() => {
    if (!state) {
      return;
    }
    // In case our form action returns `error` we can now `setError`s
    if (state.status === 'error') {
      toast({
        description: 'Error on save',
      });
      state.errors?.forEach((error) => {
        form.setError(error.path as FieldPath<FormValues>, {
          message: error.message,
        });
      });
    }
    if (state.status === 'success') {
      toast({
        description: 'Saved with success',
      });
    }
  }, [state, form, form?.setError]);

  return (
    <Form {...form}>
      <form action={formAction} className="w-2/5 space-y-6">
        <FormField
          control={form.control}
          name="id"
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <Input type="hidden" {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="firstName"
          render={({ field }) => (
            <FormItem>
              <FormLabel>First Name</FormLabel>
              <FormControl>
                <Input placeholder="John" {...field} />
              </FormControl>
              <FormDescription>
                This is the employee first name.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="lastName"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Last Name</FormLabel>
              <FormControl>
                <Input placeholder="Doe" {...field} />
              </FormControl>
              <FormDescription>
                This is the employee last name.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input placeholder="jdoe@mail.com" {...field} />
              </FormControl>
              <FormDescription>
                This is the employee email
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="jobTitle"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Job Title</FormLabel>
              <FormControl>
                <Input placeholder="Software Engineer" {...field} />
              </FormControl>
              <FormDescription>
                This is the employee Job title.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* ADDING dateOfJoining as hidden because server action was not able to get the date value from the Calendar component below */}
        <input type="hidden" name="dateOfJoining" value={date} />
        <FormField
          control={form.control}
          name="dateOfJoining"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Date of Joining</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={'outline'}
                      className={cn(
                        'w-[240px] pl-3 text-left font-normal',
                        !field.value && 'text-muted-foreground'
                      )}
                    >
                      {field.value ? (
                        format(field.value, 'MM/dd/yyyy')
                      ) : (
                        <span>Pick a date</span>
                      )}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={date}
                    onSelect={(date) => {
                      const convertedDate = date?.toISOString() ?? '';
                      setDate(date?.toISOString() ?? '');
                      form.setValue('dateOfJoining', convertedDate);
                      field.onChange;
                    }}
                    disabled={(date) => date < new Date('1900-01-01')}
                    initialFocus
                  />
                </PopoverContent>
              </Popover>

              <FormMessage />
            </FormItem>
          )}
        />

        <div className="flex flw-row space-x-4">
          <Button type="submit">Submit</Button>
          <Button variant="link" type="button">
            <Link href="/" prefetch={false}>
              Back
            </Link>
          </Button>
        </div>
      </form>
    </Form>
  );
}
