import { createBrowserRouter } from 'react-router-dom';

import LoginPage from '../pages/LoginPage';

const router = createBrowserRouter([
    {
        path: "/login",
        element: <LoginPage />
    }
]);