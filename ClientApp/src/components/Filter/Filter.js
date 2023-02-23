import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useState} from 'react';


export default function Filter({ filterToTable }) {
    console.log('entra a filtrar')
    const [FilterFirstName, setFilterFirstName] = useState('');
    const [FilterLastName, setFilterLastName] = useState('');
    let queryString = `/person?`
    queryString += FilterFirstName ? `FirstName=${encodeURIComponent(FilterFirstName)}` : ``
    queryString += FilterFirstName && FilterLastName ? `&` : ``;
    queryString += FilterLastName ? `LastName=${encodeURIComponent(FilterLastName)}` : ``;

    console.log(queryString)
    const FilterPeople = async () => {
            await fetch(queryString)
                .then((results) => {
                    return results.json();
                })
                .then(data => {
                    filterToTable(data);
                });
    }

    return (
        <Box align="center" m={2} pt={3}>
            <TextField
                id="standard-required"
                label="Nombre"
                variant="standard"
                value={FilterFirstName}
                onChange={(event) => { setFilterFirstName(event.target.value) }}
            />
            <TextField
                m={2}
                id="standard-required"
                label="Apellido"
                variant="standard"
                value={FilterLastName}
                onChange={(event) => { setFilterLastName(event.target.value) }}
            />
            <Button onClick={FilterPeople} variant="contained">Filtrar</Button>
        </Box>
    )
}

