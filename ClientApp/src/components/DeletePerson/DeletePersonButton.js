import Button from '@mui/material/Button';

export default function DeletePersonButton (props) {
  const {data, deletePersonToTable, notify, setNotify, confirmDialog, setConfirmDialog} = props;

    const deletePerson = async (p) => {
      
      setConfirmDialog({
        ...confirmDialog,
        isOpen: false,
      })
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

        // TODO: check return status
        setNotify({
          isOpen: true,
          message: 'Se eliminó correctamente',
          type: 'success'
      })


      }

    return (
        <Button 
        onClick={() => setConfirmDialog({
          isOpen: true,
          title: "Estas seguro de que queres borrar a esa persona?",
          subtitle: "esta operación no se puede deshacer",
          onConfirm: () => deletePerson(data)
        })} 
        variant="outlined" 
        color="error">Borrar</Button>
    )
}