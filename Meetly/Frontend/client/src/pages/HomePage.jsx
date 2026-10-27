import Header from "../components/Header";
import Footer from "../components/Footer";
import { useEffect, useState } from "react";
import { getMeets, apiFetchCall } from "../api/Api";
import MeetingCard from "../components/MeetingCard";
import { formatDateTime } from "../utils/formatDate";

export default function HomePage() {
    const [meetups, setMeetups] = useState([]);
    const [searchText, setSearchText] = useState("");
    const [isSearching, setIsSearching] = useState(false);
    const [errorMessage, setErrorMessage] = useState("");
    const [noResultsMessage, setNoResultsMessage] = useState("");

    useEffect(() => {
        // This prevents initial-load responses
        let ignore = false;

        getMeets()
            .then((results) => {
                if (!ignore) {
                    setMeetups(results);
                }
            })
            .catch((error) => {
                if (!ignore) {
                    console.error(error);
                    setErrorMessage("Could not load meetups.");
                }
            });

        return () => {
            ignore = true;
        };
    }, []);

    async function handleSearch(event) {
        event.preventDefault();

        setIsSearching(true);
        setErrorMessage("");
        setNoResultsMessage("");

        try {
            const submittedText = searchText.trim();
            const query = encodeURIComponent(submittedText);

            const results = await apiFetchCall(
                `meetups/search?searchText=${query}`
            );

            setMeetups(results);

            if (results.length === 0) {
                setNoResultsMessage(
                    submittedText 
                        ? `No meetups found for "${submittedText}". Try another search.`
                        : `No meetups are available yet.`
                )
            }
        } catch (error) {
            console.error(error);
            setErrorMessage("Could not search meetups. Please try again.");
        } finally {
            setIsSearching(false);
        }
    }

    return (
        <section>
            <Header
                searchText={searchText}
                onSearchTextChange={setSearchText}
                onSearch={handleSearch}
                isSearching={isSearching}
            />

            {errorMessage && (
                <p role="alert">{errorMessage}</p>
            )}

            {noResultsMessage && (
                <p className="no-results-message" role="status">
                    {noResultsMessage}
                </p>
            )}

            <main className="meeting-grid">
                {meetups.map((m) => (
                    <MeetingCard
                        key={m.id}
                        id={m.id}
                        title={m.title}
                        description={m.description}
                        location={m.place}
                        date={formatDateTime(m.time)}
                        host={m.host}
                        imageUrl={m.imageUrl}
                    />
                ))}
            </main>

            <Footer />
        </section>
    );
}
