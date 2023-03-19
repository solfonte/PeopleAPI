import Button from '@mui/material/Button';
import { useState, useEffect } from 'react';

const sendDeletePersonRequest = async (id) => {
  const deleteParameters = {
    method: "DELETE",
    headers: {
        Accept: "application/json",
        'Content-Type': 'application/json',
    },
  };
  return await fetch (`people/${id}`, deleteParameters)

}

export default function DeletePersonButton (props) {
    const {data, deletePersonToTable, notify, setNotify, confirmDialog, setConfirmDialog} = props;
    const deletePerson = async (p) => {
        
      let response = await sendDeletePersonRequest(p.id);
      deletePersonToTable(p.id);

      if (response.status === 200){
        setNotify({
            isOpen: true,
            message: 'Se eliminó correctamente',
            type: 'success'
        })
      }else if (response.status === 404){
        setNotify({
            isOpen: true,
            message: 'No se encontró a la persona',
            type: 'error'
        })
      }else {
        setNotify({
            isOpen: true,
            message: 'Ocurrió un error interno al borrar a la persona. No se pudo completar la operación',
            type: 'error'
        }
      )
    }
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