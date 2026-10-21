

// export default function MeetingCard(){
//     return (
//         <section className="MeetingCard-class">
//             <h2>
//                 TITEL
//             </h2>
//             <img src="https://www.w3schools.com/images/w3schools_green.jpg" alt="W3Schools.com"></img>
//         </section>
//     );
// }

export default function MeetingCard({title, description, host, date, imageUrl}){
    return(
        <section className="MeetingCard-class">
            <div className="MeetingCardLeft">
                <img src={imageUrl} alt="{title}" />
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
    );
}