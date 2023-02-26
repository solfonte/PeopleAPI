import {useState} from 'react';
import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import {
  createTheme,
  responsiveFontSizes,
  ThemeProvider,
} from '@mui/material/styles';
import { List } from 'reactstrap';
import { ListItem } from '@mui/material';
import PersonForm from './PersonForm';

let theme = createTheme();
theme = responsiveFontSizes(theme);



export const NewPerson = () => {
    const [notify, setNotify] = useState({isOpen: false, message: '', type: ''});

    const trySubmit = async (firstName, lastName, nationalID, age) => {

        //TODO: validations
        const postParameters = {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            }, 
            body: JSON.stringify({
                "FirstName": firstName,
                "LastName": lastName,
                "NationalID": nationalID,
                "Age": age
            })
        };

        let response = await fetch (
            `person/`,
            postParameters
        )

        if (response.status === 200) {
            console.log("okooo")
        }
        //TODO: check return status
        setNotify({
            isOpen: true,
            message: 'Se agrego correctamente',
            type: 'success'
        })
    }

    return (
      <PersonForm data={{}}
       parentFunction={trySubmit}
        operationType="Agregar"
        notify={notify}
        setNotify={setNotify}/>
    );
  }