import React, { useState, useEffect } from "react";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";


// This is a temporary function until we have fixed a real integartion with the database
function generateMockMeets(count) { 
  const titles = ["React Workshop", "Sprint Planning", "Lunch & Learn", "Architecture Review", "Board Games", "Gym Session"];
  const places = ["Room 101", "Online (Teams)", "Cafeteria", "Main Auditorium", "Room 404"];

  return Array.from({ length: count }, (_, index) => {
    const pastDate = new Date();
    pastDate.setDate(pastDate.getDate() - (index * 2));

    return { //Basicly när vi integrer med riktig databas då är det dessa som vi behöver lägga in
      id: index + 1,
      title: `${titles[index % titles.length]} #${index + 1}`,
      description: `Historical meeting notes and agenda for session ${index + 1}.`,
      place: places[index % places.length],
      time: pastDate.toISOString(),
      maxCapacity: 5 + (index % 15),
    };
  });
}

export default function Account() {
    // Bara hämtar lite skit
  const { logout } = useAuth();
  const navigate = useNavigate();

  const [meets, setMeets] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => { // skapar 20 mock meetings och säter loading till false
    const timer = setTimeout(() => {
      setMeets(generateMockMeets(20));
      setLoading(false);
    }, 500);

    return () => clearTimeout(timer);
  }, []);

  const formatDate = (dateString) => {
    return new Date(dateString).toLocaleDateString("en-US", {
      month: "short",
      day: "numeric",
      year: "numeric",
      hour: "2-digit",
      minute: "2-digit",
    });
  };

  return (
    <div className="account-page">
      <aside className="account-sidebar">
        <div className="account-user-info">
          <div className="account-avatar">A</div>
          <h2>Alex Johnson</h2>
          <span className="account-role">Member</span>
        </div>
        <button
          type="button"
          className="account-logout-btn"
          onClick={() => {
            logout();
            navigate("/");
          }}
        >
          Log Out
        </button>
      </aside>

      <main className="account-history">
        <h2>Meeting History ({meets.length})</h2>

        {loading ? (
          <p>Loading meetings...</p>
        ) : (
          <div className="meets-scroll-container">
            <ul className="meets-scroll-list">
              {meets.map((meet) => (
                <li key={meet.id} className="meet-card">
                  <h3>{meet.title}</h3>
                  <p>{meet.description}</p>
                  <div className="meet-meta">
                    <span>{meet.place}</span>
                    <span>{formatDate(meet.time)}</span>
                    <span>Capacity: {meet.maxCapacity}</span>
                  </div>
                </li>
              ))}
            </ul>
          </div>
        )}
      </main>
    </div>
  );
}