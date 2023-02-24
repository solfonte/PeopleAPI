import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom'

export default function ReturnButton ({path}) {

    let navigate = useNavigate(); 
    const returnToPath = () =>{ 
    navigate(path);
    }

    return (
        <div align="center">
            <Button onClick={returnToPath} color="info">Volver</Button>
        </div>
        
    );
} 