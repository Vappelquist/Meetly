import Header from "../components/Header"
import Login from "../components/Login";

export default function LoginPage(){
    return(
        <>
        <Header/>

        <div className="login-container">
            <Login/>
        </div>
        </>
    );
}