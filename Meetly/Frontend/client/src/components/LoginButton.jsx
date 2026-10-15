import "../App.css"
import { useNavigate } from "react-router-dom";

export default function LoginButton() {

    const navigate = useNavigate();

    return (
        <button className="LoginButton-class" onClick={() => navigate("/login")}>
            LOGIN
        </button>
    );
}