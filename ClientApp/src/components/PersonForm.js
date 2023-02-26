import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import {
  createTheme,
  responsiveFontSizes,
  ThemeProvider,
} from '@mui/material/styles';
import Typography from '@mui/material/Typography';
import { List } from 'reactstrap';
import { ListItem } from '@mui/material';
import {useState, useEffect} from 'react';
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import Notification from './Notification';


let theme = createTheme();
theme = responsiveFontSizes(theme);

export default function PersonForm({data, operationType, parentFunction, setNotify, notify}) {
    const [firstName, setFirstName] = useState(data["firstName"]? data["firstName"] : '');
    const [lastName, setLastName] = useState(data["lastName"]? data["lastName"] : '');
    const [nationalID, setNationalID] = useState(data["nationalID"]? data["nationalID"] : '');
    const [age, setAge] = useState(data["age"]? data["age"] : '');

    const HandleClick = () => {
      console.log("llega bienn")
      parentFunction(firstName, lastName, nationalID, age);
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
            <Typography variant="h4">{operationType} a una persona</Typography>
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
        <Button
          fullWidth
          variant="contained"
          color="primary"
          onClick={HandleClick}>
          {operationType}
        </Button>
        <Notification notify={notify} setNotify={setNotify}/>
      </Box>
    );
}