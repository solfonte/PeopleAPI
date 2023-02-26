import { People } from "./components/People";
import { NewPerson } from "./components/NewPerson";
import { EditPerson } from "./components/EditPerson";
import { Home } from "./components/Home"

const AppRoutes = [
  {
    index: 1,
    element: <Home/>
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
