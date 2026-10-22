import Header from "../components/Header"
import Footer from "../components/Footer"
// import MeetingCard from "../components/MeetingCard"
import { useEffect, useState } from "react";
import { getMeets } from "../api/Api";
import MeetingList from "../components/MeetingList";
import MeetingCard from "../components/MeetingCard";

export default function HomePage() {
const [meetups, setMeetups] = useState ([]);

useEffect(() => {
const controller = new AbortController();

getMeets(controller.signal)
      .then(setMeetups)
      .catch((err) => {
        if (err.name !== "AbortError") console.error(err);
      });

    return () => controller.abort();
  }, []);

  return (
    <section>
      <Header />
      <main className="meeting-grid">
{meetups.map((m)=>(
  <MeetingCard
  key={m.id}
  id={m.id}
  title={m.title}
  description={m.description}
  location={m.place}
  date={new Date(m.time).toLocaleString("sv-SE")}
  host={m.host}
  />
))}
      </main>
      <Footer />
    </section>
  )
}