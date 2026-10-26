import { data, Link } from "react-router-dom";



export default function MeetingCard({id, title, description, host, date, imageUrl}){
    return(
        <Link to={`/meetup/${id}`} className="MeetingCard-link">
        <section className="MeetingCard-class">
            <div className="MeetingCardLeft">
                {imageUrl && <img src={imageUrl} alt={title} />}                
                <p>{date}</p>
            </div>
            <div className="MeetingCardRight">
                <h2>{title}</h2>
                <p>{description}</p>
            </div>
            <div className="MeetingCardBottomRight">
                <p>{host}</p>
            </div>
        </section>
        </Link>
    );
}