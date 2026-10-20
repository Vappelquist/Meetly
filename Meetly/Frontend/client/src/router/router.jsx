import { createBrowserRouter } from 'react-router-dom';

import LoginPage from '../pages/LoginPage';
import HomePage from '../pages/HomePage';
import AccountPage from '../pages/AccountPage';

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
    }
]);

export default router;