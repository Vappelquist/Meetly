import { useEffect, useState } from "react";
import MeetingCard from "./MeetingCard";

export default function MeetingList(){
    const [events, setEvents] = useState([]);

    useEffect(() =>{
        const controller = new AbortController();

        fetch("/api/events", {signal: controller.signal})
        .then((res) => res.json())
        .then (setEvents)
        .catch((err) => {
            if (err.name !== "AbortError") console.error(err);
        });
        return () => controller.abort();
    }, []);

    return (
        <>
        {events.map((e) =>(
            <MeetingCard
            key={e.id}
            title={e.title}
            description={e.description}
            host={e.host}
            date={e.date}
            imageUrl={e.imageUrl}
        />
        ))}
        </>
    );
}