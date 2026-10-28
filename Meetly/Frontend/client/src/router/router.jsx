import { createHashRouter } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import HomePage from '../pages/HomePage';
import AccountPage from '../pages/AccountPage';
import SignUpPage from '../pages/SignUpPage';
import MoreInfoPage from '../pages/MoreInfo';
import CreateMeetupPage from '../pages/CreateMeetupPage';


const router = createHashRouter([
// const router = createBrowserRouter([
    {
        path: "/",
        element: <HomePage />
    },
    {
        path: "/login",
        element: <LoginPage />
    },
    {
        path: "/Account",
        element: <AccountPage />
    },
    {
        path: "/SignUp",
        element: <SignUpPage />
    },
    
    {
        path: "/meetup/:id",
        element: <MoreInfoPage /> 
    },
    { 
        path: "/create", 
        element: <CreateMeetupPage/> 
    }
]);

export default router;