import Header from "../components/Header";
import Login from "../components/Login";
import BackButton from "../components/BackButton";

export default function LoginPage() {
    return (
        <div className="login-page-layout">
            <Header />
            <BackButton/>
            <div className="login-wrapper">
                <Login />
            </div>
        </div>
    );
}