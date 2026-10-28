import { createContext, useContext, useState } from "react";

const AuthContext = createContext();

export function AuthProvider({ children }) {
    const [user, setUser] = useState(() => {
        try {
            return JSON.parse(localStorage.getItem("user"));
        } catch {
            return null;
        }
    });

    const login = (userData) => {
        const normalized = {
            id: userData.userId ?? userData.id,
            username: userData.username,
            token: userData.token,
        };
        localStorage.setItem("user", JSON.stringify(normalized));
        setUser(normalized);
    };

    const logout = () => {
        localStorage.removeItem("user");
        setUser(null);
    };

    return (
        <AuthContext.Provider
            value={{
                user,
                token: user?.token || null,
                isLoggedIn: Boolean(user?.token),
                login,
                logout,
            }}
        >
            {children}
        </AuthContext.Provider>
    );
}

export const useAuth = () => useContext(AuthContext);