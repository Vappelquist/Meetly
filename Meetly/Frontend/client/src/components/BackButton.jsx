import "../App.css"
import { useNavigate } from "react-router-dom";

export default function LoginButton() {

    const navigate = useNavigate();

    return (
        <button className="BackButton-class" onClick={() => navigate("/")}>
            Back
        </button>
    );
}