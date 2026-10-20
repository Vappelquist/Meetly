import "../App.css";
import { useNavigate } from "react-router-dom";

export default function LoginButton({ setLoginStatus }) {
    const navigate = useNavigate();

    const handleClick = () => {
        setLoginStatus(true);
        localStorage.setItem("loggedInToken", "True");
        navigate("/");
    };

    return (
        <button className="LoginButton-class" onClick={handleClick}>
            LOGIN
        </button>
    );
}