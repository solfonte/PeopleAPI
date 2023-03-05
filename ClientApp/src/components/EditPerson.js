import PersonForm from './PersonForm';
import ReturnButton from './ReturnButton'
import { useEffect, useState } from 'react';

const sendEditPersonRequest = async (id, body, setResponseStatus) => {
    const editParameters = {
        method: "PATCH",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(body)
      };
    await fetch ("person/" + id, editParameters)
            .then((response) => {
                setResponseStatus({
                    status: response.status
                })
                if(!response.ok) throw new Error(response.status);
                return response.json()})
            .then((data) => {
                sessionStorage.setItem("personToEdit", JSON.stringify(data))
            }).catch((e) => console.log(e))
}

export const EditPerson = () => {
    let person = JSON.parse(sessionStorage.getItem("personToEdit"))
    const [responseStatus, setResponseStatus] = useState({status: 0});
    const [notify, setNotify] = useState({isOpen: false, message: '', type: ''})

    useEffect(() => {
        if (responseStatus.status === 0) return;
        if (responseStatus.status === 200){
            setNotify({
                isOpen: true,
                message: 'Se edito correctamente',
                type: 'success'
            })
        }else if (responseStatus.status === 422){
            setNotify({
                isOpen: true,
                message: 'Faltan argumentos',
                type: 'error'
            })
        }else if (responseStatus.status === 404){
            setNotify({
                isOpen: true,
                message: 'No se encontró a la persona',
                type: 'error'
            })
        }else if (responseStatus.status === 409){
            setNotify({
                isOpen: true,
                message: 'Ya existe una persona con ese numero de DNI',
                type: 'error'
            })
        }else {
            setNotify({
                isOpen: true,
                message: 'Ocurrió un error interno al editar a la persona. No se pudo completar la operación',
                type: 'error'
            })
        }
    }, [responseStatus]);


    const EditPersonFields = async (firstName, lastName, nationalID, age) => {
    const body = {
        "FirstName": firstName,
        "LastName": lastName,
        "NationalID": '' + nationalID,
        "Age": age
    }

    await sendEditPersonRequest(person.id, body, setResponseStatus);      
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