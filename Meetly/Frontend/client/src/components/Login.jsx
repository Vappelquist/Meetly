import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { useState } from "react";

const API_URL = import.meta.env.VITE_API_URL;

export default function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const navigate = useNavigate();
    const { login } = useAuth();

    const handleLogin = async (e) => {
        if (e) e.preventDefault();
        setErrorMessage("");

        try {
            const response = await fetch(`${API_URL}/api/Auth/login`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    Username: username,
                    Password: password,
                }),
            });

            if (!response.ok) {
                const message = await response.text();
                setErrorMessage(message || "Invalid username or password.");
                return;
            }

            const responseData = await response.json();
            login(responseData);
            navigate("/");
        } catch (error) {
            console.error("Fetch error:", error);
            setErrorMessage("Could not connect to the backend.");
        }
    };

    return (
        <div className="login-card">
            {errorMessage && <p style={{ color: "red", margin: "0 0 10px 0" }}>{errorMessage}</p>}
            
            <input
                type="text"
                placeholder="Username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
            />
            
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />

            <button type="button" className="login-submit-btn" onClick={handleLogin}>
                Login
            </button>
            <button className="HeaderTitle-class" onClick={() => navigate("/SignUp")}>
                <h4>Signup by clicking here</h4>
            </button>
        </div>
    );
}