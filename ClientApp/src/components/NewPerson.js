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
import Typography from '@mui/material/Typography';
import { List } from 'reactstrap';
import { ListItem } from '@mui/material';
import PersonForm from './PersonForm';

let theme = createTheme();
theme = responsiveFontSizes(theme);



export const NewPerson = () => {

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
        
    }

    return (
      <PersonForm data={{}} parentFunction={trySubmit} operationType="Agregar"/>
    );
  }