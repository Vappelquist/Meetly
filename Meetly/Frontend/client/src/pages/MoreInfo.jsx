import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {getMeetById} from "../api/Api"

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

    return(
        <main>
            <h1>{meetup.title}</h1>
            <p>{meetup.description}</p>
            <p>{meetup.place}</p>
            <p>{new Date(meetup.time).toLocaleString("sv-SE")}</p>            <p>Host: {meetup.host}</p>
            <p>Max amount: {meetup.maxCapacity}</p>
        </main>
    )
}
