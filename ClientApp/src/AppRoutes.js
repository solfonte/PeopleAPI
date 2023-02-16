import { Counter } from "./components/Counter";
import { Home } from "./components/Home";
import { People } from "./components/People";

const AppRoutes = [
  {
    path: '/counter',
    element: <Counter />
  },
  {
    index: true,
    path: '/fetch-people',
    element: <People/>
  }
];

export default AppRoutes;
