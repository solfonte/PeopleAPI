import { Dialog, DialogContent, DialogTitle, DialogActions } from "@mui/material";
import Typography from '@mui/material/Typography';
import Button from "@mui/material/Button";
import ReportGmailerrorredIcon from '@mui/icons-material/ReportGmailerrorred';

export default function ConfirmDialog (props){
    const {title, subtitle, color, confirmDialog, setConfirmDialog} = props;

    return (
        <Dialog open={confirmDialog.isOpen}>
            <ReportGmailerrorredIcon fontSize="large"/>
            <DialogTitle>
            </DialogTitle>
            <DialogContent>
                <Typography variant="h6">
                    {confirmDialog.title}
                </Typography>
                <Typography variant="subtitle1">
                    {confirmDialog.subtitle}
                </Typography>
            </DialogContent>
            <DialogActions>
                <Button color="primary" variant="contained" onClick={confirmDialog.onConfirm}>Yes</Button>
                <Button color="primary" variant="outlined" onClick={() => setConfirmDialog({...confirmDialog, isOpen:false})}>No</Button>
            </DialogActions>
        </Dialog>
    )
}