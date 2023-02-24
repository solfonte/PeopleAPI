import { People } from "./components/People";
import { NewPerson } from "./components/NewPerson";
import { EditPerson } from "./components/EditPerson";

const AppRoutes = [
  {
    index: 1,
    element: <People/>
  },
  {
    path: '/People',
    element: <People/>
  },
  {
    path: '/New-Person',
    element: <NewPerson/>
  },
  {
    path: '/Edit-Person',
    element: <EditPerson/>
  }

];

export default AppRoutes;
