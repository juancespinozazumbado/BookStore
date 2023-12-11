// import "./App.css";
import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import Home from './Pages/Home';
import Login from './Pages/Auth/Login'
import Register from './Pages/Auth/Register'
import Books from './Pages/Books/Books'
import ErrorPage from './Pages/ErrorPage';


const router = createBrowserRouter([
  {
    path : "/",
    element : <Home/>,
    errorElement: <ErrorPage/>
  },
  {
    path : "/Login",
    element: <Login/>,
    errorElement: <ErrorPage/>
  },
  {
    path : "/Register",
    element: <Register/>,
    errorElement: <ErrorPage/>
  },
  {
    path : "/Books",
    element: <Books/>,
    errorElement: <ErrorPage/>
  }

])
const App = () => {
  return (
    <>
      <RouterProvider router={router}/>
    </>
  );
};

export default App;
