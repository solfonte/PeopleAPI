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
    const [age, setAge] = useState(data["age"]? data["age"] : null);

    const HandleClick = () => {
      parentFunction(firstName, lastName, nationalID, age);
    }

    const handleAgeChange = (e) => {
      const regex = /^[0-9\b]+$/;
      if (e.target.value === "" || regex.test(e.target.value)) {
        setAge(e.target.value)
      }else{
        setNotify({
          isOpen: true,
          message: 'Sólo se aceptan numeros positivos de edad',
          type: 'error'
      })
      }
    }

    const handleNationalIDChange = (e) => {
      const regex = /^[0-9\b]+$/;
      if (e.target.value === "" || regex.test(e.target.value)) {
        setNationalID(e.target.value)
      }else{
        setNotify({
          isOpen: true,
          message: 'Sólo se aceptan numeros positivos de DNI',
          type: 'error'
      })
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
            <Typography variant="h4">{operationType} a una persona</Typography>
          </ThemeProvider>
        </div>
        <div align="left">

        <ThemeProvider theme={theme} textAlign="left">
          <Typography variant="h6">
              <List sx={{ display: 'list-item' }}>
                <ListItem>El nombre, el apellido y el DNI son campos requeridos.</ListItem>
                <ListItem>Luego, si ingresaste una edad, vamos a poder calcular la etapa de edad de la persona ingresada.</ListItem>   
                <ListItem>Si el DNI de la persona ya esta ingresado en la base con un mismo nombre y apellido, no se va a poder crear la persona.</ListItem>  
              </List>

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
            onChange={(e) => {handleNationalIDChange(e)}}
          />
          <TextField
            label="Edad"
            type="number"
            variant="standard"
            value={age}
            onChange={(e) => {handleAgeChange(e)}}
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