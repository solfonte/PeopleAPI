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

let theme = createTheme();
theme = responsiveFontSizes(theme);



export const NewPerson = () => {

    const [firstName, setFirstName] = useState([]);
    const [lastName, setLastName] = useState([]);
    const [nationalID, setNationalID] = useState([]);
    const [age, setAge] = useState([]);

    const trySubmit = async () => {

        //TODO: validations
        console.log("entroo")
    
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
      <Box
        component="form"
        sx={{
          '& .MuiTextField-root': { m: 1, width: '25ch' },
        }}
        noValidate
        autoComplete="off"
      >
        <div align="center">
          <ThemeProvider theme={theme}>
            <Typography variant="h4">Agrega a una nueva persona!</Typography>
          </ThemeProvider>
        </div>
        <div align="left">
  
        <ThemeProvider theme={theme}>
          <Typography variant="h6">
              <List sx={{ display: 'list-item' }}>
                <ListItem>El nombre, el apellido y el DNI son campos requeridos.</ListItem>
              </List>
  
              El nombre, el apellido y el DNI son campos requeridos.   
              Luego, si ingresaste una edad, vamos a poder calcular
              el AgeStage de la persona ingresada.
              Si el DNI de la persona ya esta ingresado en la base con un mismo nombre y apellido, no se va a poder crear la persona. 
          </Typography>
        </ThemeProvider>
        </div>
        <Box align="center">
          <TextField
            required
            id="standard-required"
            label="Nombre"
            variant="standard"
            value={firstName}
            onChange={(event) => {setFirstName(event.target.value)}}
          />
          <TextField
            required
            id="standard-required"
            label="Apellido"
            variant="standard"
            value={lastName}
            onChange={(event) => {setLastName(event.target.value)}}
          />
          </Box>
          <Box align="center">
          <TextField
            required
            id="standard-required"
            label="DNI"
            type="number"
            variant="standard"
            value={nationalID}
            onChange={(event) => {setNationalID(event.target.value)}}
          />
          <TextField
            label="Edad"
            type="number"
            variant="standard"
            value={age}
            onChange={(event) => {setAge(event.target.value)}}
          />
        </Box>
        <Box align="center" m={2} pt={3}>
                <Button onClick={trySubmit} variant="contained">Agregar</Button>
        </Box>
      </Box>
    );
  }