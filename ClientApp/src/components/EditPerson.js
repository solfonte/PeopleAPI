import PersonForm from './PersonForm';
import ReturnButton from './ReturnButton'
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Alert from '@mui/material/Alert';;


export const EditPerson = () => {
  let person = JSON.parse(sessionStorage.getItem("personToEdit"))
  const [status, setStatus] = useState(undefined);
  const [notify, setNotify] = useState({isOpen: false, message: '', type: ''})

    const EditPersonFields = async (firstName, lastName, nationalID, age) => {
        
        const editParameters = {
            method: "PATCH",
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
        await fetch ("person/" + person.id, editParameters)
        await fetch ("person/" + person.id)
            .then((response) => {
                if (response.status == 200){
                    
                }
                return response.json()})
            .then((data) => {sessionStorage.setItem("personToEdit", JSON.stringify(data))})
        //TODO: check status
        setNotify({
            isOpen: true,
            message: 'Se edito correctamente',
            type: 'success'
        })
    }
    return (
            <main>
                <PersonForm 
                data={person} 
                parentFunction={EditPersonFields} 
                operationType="Editar"
                setNotify={setNotify}
                notify={notify}/>
                <ReturnButton path={`/people`}/>
                
            </main>
        );
}