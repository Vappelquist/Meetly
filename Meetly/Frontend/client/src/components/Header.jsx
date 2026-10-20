import LoginButton from "../components/LoginButton"
import { useNavigate } from "react-router-dom";
import ToAccountButton from "./ToAccountButton";
import { useAuth } from "../context/AuthContext";

export default function Header(){
    const { isLoggedIn } = useAuth(); 

    const navigate = useNavigate();

    return (
        <header className="header-class">
            <button className="HeaderTitle-class" onClick={() => navigate("/")}>
                <h1>
                    Meetly
                </h1>
            </button>
            <div>
                {isLoggedIn ? <ToAccountButton /> : <LoginButton />}
            </div>
        </header>
    );
}