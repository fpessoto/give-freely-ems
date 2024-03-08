export default function EditEmployee({
  params,
}: {
  params: { id: string };
}) {
  return <h1>Employee page {params.id}</h1>;
}
