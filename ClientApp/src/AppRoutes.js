import { People } from "./components/People";
import { NewPerson } from "./components/NewPerson";

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
  }

];

export default AppRoutes;
