import Header from "../components/Header";
import Login from "../components/Login";

export default function LoginPage() {
    return (
        <div className="login-page-layout">
            <Header />
            <div className="login-wrapper">
                <Login />
            </div>
        </div>
    );
}