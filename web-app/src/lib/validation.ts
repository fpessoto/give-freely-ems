import { zfd } from "zod-form-data";
import { z } from "zod";

export const formSchema =
  zfd.formData({
    id: z.string().optional(),
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
    dateOfJoining: z.coerce
      .date({
        required_error: 'Please select a valid date',
      })
      .min(new Date('1900-01-01'), { message: 'Too old' }),
  });