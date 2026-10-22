import LoginButton from "../components/LoginButton";
import { useNavigate } from "react-router-dom";
import ToAccountButton from "./ToAccountButton";
import { useAuth } from "../context/AuthContext";

export default function Header({
    searchText = "",
    onSearchTextChange,
    onSearch,
    isSearching = false
}) {
    const { isLoggedIn } = useAuth();
    const navigate = useNavigate();

    return (
        <header className="header-class">
            <button
                className="HeaderTitle-class"
                onClick={() => navigate("/")}
            >
                <h1>Meetly</h1>
            </button>

            {onSearch && (
                <form
                    className="header-search"
                    role="search"
                    onSubmit={onSearch}
                >
                    <input
                        type="search"
                        aria-label="Search meetups by title or description"
                        placeholder="Search meetups..."
                        value={searchText}
                        onChange={(event) =>
                            onSearchTextChange(event.target.value)
                        }
                        disabled={isSearching}
                    />

                    <button type="submit" disabled={isSearching}>
                        {isSearching ? "Searching..." : "Search"}
                    </button>
                </form>
            )}

            <div className="header-account">
                {isLoggedIn ? <ToAccountButton /> : <LoginButton />}
            </div>
        </header>
    );
}