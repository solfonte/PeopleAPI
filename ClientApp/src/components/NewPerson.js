import {useState} from 'react';
import * as React from 'react';
import {
  createTheme,
  responsiveFontSizes
} from '@mui/material/styles';
import PersonForm from './PersonForm';

let theme = createTheme();
theme = responsiveFontSizes(theme);

const notifyResult = (status, setNotify) => {
    if (status === 200){
        setNotify({
            isOpen: true,
            message: 'Se agregó correctamente',
            type: 'success'
        })
    }else if (status === 422){
        setNotify({
            isOpen: true,
            message: 'Faltan argumentos',
            type: 'error'
        })
        // TTODO: en rojo los required fields   
    }else {
        setNotify({
            isOpen: true,
            message: 'Ocurrió un error interno al agregar a la persona. No se pudo completar la operación',
            type: 'error'
        })
    }
}

const sendPostRequest = async (body) => {
    const postParameters = {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        }, 
        body: JSON.stringify(body)
    };

    let response = await fetch (
        `person/`,
        postParameters
    )
    
    return response;
}


export const NewPerson = () => {
    const [notify, setNotify] = useState({isOpen: false, message: '', type: ''});

    const trySubmit = async (firstName, lastName, nationalID, age) => {

        const body = {
            "FirstName": firstName,
            "LastName": lastName,
            "NationalID": '' + nationalID,
            "Age": age
        }

        let response = await sendPostRequest(body);

        notifyResult(response.status, setNotify);
    }

    return (
      <PersonForm data={{}}
       parentFunction={trySubmit}
        operationType="Agregar"
        notify={notify}
        setNotify={setNotify}/>
    );
  }