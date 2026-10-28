import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {getMeetById} from "../api/Api"
import Header from "../components/Header";
import Footer from "../components/Footer";
import { Link } from "react-router-dom";
import { formatDateTime } from "../utils/formatDate";
import AttendanceButton from "../components/RegisterButtons";

export default function MoreInfoPage(){
    const {id} = useParams();
    const [meetup, setMeetup] = useState(null)

    useEffect(()=> {
        const controller = new AbortController();
        getMeetById(id, controller.signal)
        .then(setMeetup)
        .catch((err) =>{
            if (err.name !== "AbortError") console.error(err);
        });
        return () => controller.abort()

    }, [id]);

    if (!meetup) return <p>Loading...</p>;



    return (
    <section>
        <Header />
        <main className="moreinfo-page">
            <Link to="/" className="moreinfo-back">Back</Link>

            <article className="moreinfo-card">
                {meetup.imageUrl && (
                  <img className="moreinfo-image" src={meetup.imageUrl} alt={meetup.title} />
                )}
                <h1 className="moreinfo-title">{meetup.title}</h1>

                <dl className="moreinfo-meta">
                    <div>
                        <p>Time</p>
                        <p>{formatDateTime(meetup.time)}</p>
                    </div>
                    <div>
                        <p>Location</p>
                        <p>{meetup.place}</p>
                    </div>
                    <div>
                        <p>Host</p>
                        <p>{meetup.host}</p>
                    </div>
                    <div>
                        <p>Max amount</p>
                        <p>{meetup.maxCapacity}</p>
                    </div>
                </dl>

                <h2 className="moreinfo-subtitle">Description</h2>
                <p className="moreinfo-description">{meetup.description}</p>
            </article>
            <AttendanceButton meetId={meetup.id} />
            </main>
        <Footer />
    </section>
);
}
