export default function MeetingCard(){
    return (
        <section className="MeetingCard-class">
            <div className="MeetingCardLeft">
                <img src="https://www.w3schools.com/images/w3schools_green.jpg" alt="W3Schools.com"></img>
                <p>Date/Time</p>
            </div>
            <div className="MeetingCardRight">
                <h2>TITEL</h2>
                <p>Location</p>
                <p>Description</p>
            </div>
            <div className="MeetingCardBottomRight">
                <p>Arranger</p>
            </div>
        </section>
    );
}