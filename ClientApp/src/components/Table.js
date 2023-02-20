import React from 'react';
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';

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
  


export default function CustomizedTables(people) {
    return (
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
                            <Button variant="outlined" color="error">Erase</Button>
                            <Button color="secondary">Edit</Button>
                        </div>
                    </StyledTableCell>
                  </StyledTableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
    )
}