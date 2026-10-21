import SignUp from "../components/SignUp";
import BackButton from "../components/BackButton";

export default function LoginPage() {
    return (
        <div className="login-page-layout">
                   <BackButton/>
                   <div className="login-wrapper">
                       <SignUp />
                   </div>
               </div>
    );
}