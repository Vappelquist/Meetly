import "../App.css";
import { useNavigate } from "react-router-dom";

export default function LoginButton() {
    const navigate = useNavigate();

    return (
         <button 
            type="button"
            className="LoginButton-class" 
            onClick={() => {
                console.log("Navigating to /login...");
                navigate("/login");
            }}
        >
            LOGIN
        </button>
    );
}