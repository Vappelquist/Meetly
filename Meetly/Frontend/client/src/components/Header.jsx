import LoginButton from "../components/LoginButton"

export default function Header(){
    return (
        <header className="header-class">
            <h1>
                Meetly
            </h1>
            <h2 className="LoginButton-class">
                <LoginButton/>
            </h2>
        
        </header>
    );
}