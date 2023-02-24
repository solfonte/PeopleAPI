import Button from '@mui/material/Button';

export default function DeletePersonButton ({data, deletePersonToTable}) {
  console.log("al delete la persona le llega")
    const deletePerson = async (p) => {
  
        const deleteParameters = {
          method: "DELETE",
          headers: {
              Accept: "application/json",
              'Content-Type': 'application/json',
          },
        };
        let response = await fetch (
          `person/${p.id}`,
          deleteParameters
        )
  
        if (response.status === 200) {
          console.log("okooo")
          //TODO: mensaje exitoso
        }
        deletePersonToTable(p.id);
        //TODO: que se actualicen las personas porque ahora hay menos
      }

    return (
        <Button onClick={() => deletePerson(data)} variant="outlined" color="error">Borrar</Button>
    )
}