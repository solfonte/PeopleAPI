import React from 'react';
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import DeletePersonButton from './DeletePerson/DeletePersonButton';
import EditPersonButton from './EditPerson/EditPersonButton';

import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import {useState, useEffect} from 'react';
import Filter from './Filter/Filter';
import Notification from './Notification';
import ConfirmDialog from './ConfirmDialog';



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
    const [notify, setNotify] = useState({isOpen: false, message: '', type: ''});
    const [confirmDialog, setConfirmDialog] = useState({isOpen: false, title:'', subtitle:''});
    
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
    }

    const filterToTable = (data) => {
      setPeople(data)
      setFiltered(true)
    } 

    const deletePersonToTable = (id) => {
      setPeople((current) => 
        current.filter((person) => person.id !== id));
      setNotify()
    }

    return (
      <div>
        <Notification notify={notify} setNotify={setNotify}/>
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
                  <StyledTableCell align="center">Opciones</StyledTableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {people.map((row) => (
                  <StyledTableRow key={row.id}>
                    <StyledTableCell align="center" component="th" scope="row">{row.firstName}</StyledTableCell>
                    <StyledTableCell align="center">{row.lastName}</StyledTableCell>
                    <StyledTableCell align="center">{row.nationalID}</StyledTableCell>
                    <StyledTableCell align="center">{row.age}</StyledTableCell>
                    <StyledTableCell align="center">{row.ageStage}</StyledTableCell>

                    <StyledTableCell align="center">
                        <div direction="row" align="center" spacing={0.5}>
                            <DeletePersonButton data={row} deletePersonToTable={deletePersonToTable}
                            notify={notify} 
                            setNotify={setNotify}
                            confirmDialog={confirmDialog}
                            setConfirmDialog={setConfirmDialog}/>
                            <EditPersonButton data={row}/>
                        </div>
                    </StyledTableCell>
                  </StyledTableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        <ConfirmDialog setConfirmDialog={setConfirmDialog} confirmDialog={confirmDialog}/>

          </div>
    )
}