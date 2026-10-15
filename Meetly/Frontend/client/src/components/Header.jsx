import LoginButton from "../components/LoginButton"

export default function Header(){
    return (
        <header className="header-class">
            <h1>Meetly</h1>
            <div>
                <LoginButton/>
            </div>
        </header>
    );
}