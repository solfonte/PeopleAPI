import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom'

export default function EditPersonButton ({data}) {
    let navigate = useNavigate(); 
    const editPersonRoute = () =>{ 
        let path = `/Edit-Person`; 
        sessionStorage.setItem("personToEdit", JSON.stringify(data));
        navigate(path);
    }

    return (
        <Button onClick={editPersonRoute} color="secondary">Editar</Button>
    );
}