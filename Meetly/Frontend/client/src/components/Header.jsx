import LoginButton from "../components/LoginButton"
import { useNavigate } from "react-router-dom";

export default function Header(){
    const navigate = useNavigate();
    return (
        <header className="header-class">
            <button className="HeaderTitle-class" onClick={() => navigate("/")}>
                <h1>
                    Meetly
                </h1>
            </button>
            <div>
                <LoginButton/>
            </div>
        </header>
    );
}