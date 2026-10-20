import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function Login() {
    const navigate = useNavigate();
    const { login } = useAuth();

    const handleLogin = () => {
        login();
        navigate("/");
    };

    return (
        <div className="login-card">
            <input type="text" placeholder="Username" />
            <input type="password" placeholder="Password" />
            <button type="button" className="login-submit-btn" onClick={handleLogin}>
                Login
            </button>
        </div>
    );
}