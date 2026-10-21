import { createHashRouter } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import HomePage from '../pages/HomePage';
import AccountPage from '../pages/AccountPage';
import SignUpPage from '../pages/SignUpPage';

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
    }
]);

export default router;