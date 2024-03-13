'use client';

import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover';
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
import { Calendar } from '@/components/ui/calendar';
import { cn } from '@/lib/utils';
import { CalendarIcon } from '@radix-ui/react-icons';
import { format } from 'date-fns';
import { useToast } from '@/components/ui/use-toast';
import Link from 'next/link';

const formSchema = z.object({
  firstName: z.string().min(2, {
    message: 'First Name must be at least 2 characters.',
  }),
  lastName: z.string().min(2, {
    message: 'Last Name must be at least 2 characters.',
  }),
  email: z
    .string()
    .min(1, { message: 'This field has to be filled.' })
    .email('This is not a valid email.'),
  jobTitle: z
    .string()
    .min(2, { message: 'Job Title must be at least 2 characters' }),
  dateOfJoining: z
    .date({
      required_error: 'Please select a valid date',
    })
    .min(new Date('1900-01-01'), { message: 'Too old' }),
});

export default function EmployeeForm({}: {}) {
  const { toast } = useToast();

  // 1. Define your form.
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      firstName: '',
      lastName: '',
      email: '',
      jobTitle: '',
      dateOfJoining: new Date(),
    },
  });

  // 2. Define a submit handler.
  async function onSubmit(values: z.infer<typeof formSchema>) {
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
    } catch (error) {
      console.error(error);
    }

    console.log(values);
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="w-2/5 space-y-6"
      >
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

        <FormField
          control={form.control}
          name="dateOfJoining"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Date of birth</FormLabel>
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
                        format(field.value, 'PPP')
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
                    selected={field.value}
                    onSelect={field.onChange}
                    disabled={(date) => date < new Date('1900-01-01')}
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormDescription>
                Your date of birth is used to calculate your age.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <div className="flex flw-row space-x-4">
          <Button type="submit">Submit</Button>
          <Button variant="link" type="button">
            <Link href="/employee">Back</Link>
          </Button>
        </div>
      </form>
    </Form>
  );
}
