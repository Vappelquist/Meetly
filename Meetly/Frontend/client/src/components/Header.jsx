import LoginButton from "../components/LoginButton"
import { useNavigate } from "react-router-dom";
import ToAccountButton from "./ToAccountButton";
import { useState } from "react";

export default function Header(){
    const [isLoggedIn, setIsLoggedIn] = useState(() => {
    return !!localStorage.getItem("loggedInToken");
    });

    const navigate = useNavigate();

    return (
        <header className="header-class">
            <button className="HeaderTitle-class" onClick={() => navigate("/")}>
                <h1>
                    Meetly
                </h1>
            </button>
            <div>
                {isLoggedIn ? (
                    <ToAccountButton />
                ) : (
                    <LoginButton setLoginStatus={setIsLoggedIn} />
                )}
            </div>
        </header>
    );
}