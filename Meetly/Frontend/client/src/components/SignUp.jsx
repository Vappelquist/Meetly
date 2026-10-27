import { useNavigate } from "react-router-dom";
import { useState } from "react";

export default function SignUp() {
    const API_URL = import.meta.env.VITE_API_URL;

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const navigate = useNavigate();

    const handleSignUp = async (e) => {
        if (e) e.preventDefault();
        setErrorMessage("");

        try {
            const response = await fetch(`${API_URL}/api/Auth/register`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    name: username,
                    password: password,
                }),
            });

            if (!response.ok) {
                const errorData = await response.json().catch(() => null);
                const message = Array.isArray(errorData) ? errorData.join(", ") : await response.text();
                setErrorMessage(message || "Signup failed.");
                return;
            }

            navigate("/login");
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

            <button type="button" className="login-submit-btn" onClick={handleSignUp}>
                Sign Up
            </button>
        </div>
    );
}