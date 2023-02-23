import React from 'react';
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { Component } from 'react';
import {useState, useEffect} from 'react';
import Filter from './Filter/Filter';


const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
      backgroundColor: theme.palette.common.black,
      color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
      fontSize: 14,
    },
  }));
  
  const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
      border: 0,
    },
  }));
  

export default function CustomizedTables() {
    const [people, setPeople] = useState([]);
    const [isFiltered, setFiltered] = useState(false);
    
    useEffect(() => {
        fetch(`person`)
        .then((results) => {
            return results.json();
        })
        .then(data => {
            setPeople(data);
        })
      },[]);

    const getPeople = async () => {
      await fetch(`person`)
        .then((results) => {
            return results.json();
        })
        .then(data => {
            setPeople(data);
        })
      }

    const removeFilter = () => {
      getPeople();
      setFiltered(false);
      console.log("removed")
    }


    const deletePerson = async (p) => {
      console.log(p.id)

      
      const deleteParameters = {
        method: "DELETE",
        headers: {
            'Content-Type': 'application/json',
        },
      };
      let response = await fetch (
        `person/${p.id}`,
        deleteParameters
      )

      if (response.status === 200) {
        console.log("okooo")
      }
      //TODO: mensaje exitoso
      //TODO: que se actualicen las personas porque ahora hay menos
    }

    const filterToTable = (data) => {
      setPeople(data)
      setFiltered(true)
    }

    return (
      <div>
        <Box align="center" m={2} pt={3}>
          <Filter filterToTable={filterToTable}/>
          <Button onClick={removeFilter} disabled={!isFiltered} variant="contained" m={2}>borrar filtro</Button>
        </Box>
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 700 }} aria-label="customized table">
              <TableHead>
                <TableRow>
                  <StyledTableCell align="center">Nombre</StyledTableCell>
                  <StyledTableCell align="center">Apellido</StyledTableCell>
                  <StyledTableCell align="center">N° de documento</StyledTableCell>
                  <StyledTableCell align="center">Edad</StyledTableCell>
                  <StyledTableCell align="center">Clasificación por edad</StyledTableCell>
                  <StyledTableCell align="center">Options</StyledTableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {people.map((row) => (
                  <StyledTableRow key={row.FirstName}>
                    <StyledTableCell align="center" component="th" scope="row">{row.firstName}</StyledTableCell>
                    <StyledTableCell align="center">{row.lastName}</StyledTableCell>
                    <StyledTableCell align="center">{row.nationalID}</StyledTableCell>
                    <StyledTableCell align="center">{row.age}</StyledTableCell>
                    <StyledTableCell align="center">{row.ageStage}</StyledTableCell>

                    <StyledTableCell align="center">
                        <div direction="row" align="center" spacing={0.5}>
                            <Button onClick={() => deletePerson(row)} variant="outlined" color="error">Erase</Button>
                            <Button color="secondary">Edit</Button>
                        </div>
                    </StyledTableCell>
                  </StyledTableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
          </div>
    )
}