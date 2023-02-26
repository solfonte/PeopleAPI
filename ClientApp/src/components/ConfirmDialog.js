import { Dialog, DialogContent, DialogTitle, DialogActions } from "@mui/material";
import Typography from '@mui/material/Typography';
import Button from "@mui/material/Button";
import ReportGmailerrorredIcon from '@mui/icons-material/ReportGmailerrorred';
//import { makeStyles } from "@mui/styles";

/*
const useStyles = makeStyles(theme => ({
    dialog: {
        padding: theme.spacing(2),
        position: 'absolute',
        top: theme.spacing(5),
    },
    dialogContent: {
        textAlign: 'center'
    },
    dialogAction: {
        justifyContent: 'center'
    }
}))
*/

export default function ConfirmDialog (props){
    const {title, subtitle, color, confirmDialog, setConfirmDialog} = props;
   // const classes = useStyles()
    return (
        <Dialog open={confirmDialog.isOpen} /*classes={{paper:classes.dialog}}*/>
            <ReportGmailerrorredIcon/>
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
            <DialogActions /*classes={{paper:classes.dialogAction}}*/>
                <Button color="primary" variant="contained" onClick={confirmDialog.onConfirm}>Yes</Button>
                <Button color="primary" variant="outlined" onClick={() => setConfirmDialog({...confirmDialog, isOpen:false})}>No</Button>
            </DialogActions>
        </Dialog>
    )
}