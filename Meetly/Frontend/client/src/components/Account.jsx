import React, { useState, useEffect } from "react";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import ToCreateMeetupForm from "../components/ToCreateMeetupForm";

const API_URL = import.meta.env.VITE_API_URL;

const formatDate = (isoString) => {
  if (!isoString) return "";
  return new Date(isoString).toLocaleDateString("en-US", {
    month: "short",
    day: "numeric",
    year: "numeric",
    hour: "2-digit",
    minute: "2-digit",
  });
};

function MeetingSection({ title, meetings, emptyMessage }) {
  return (
    <section className="meets-section">
      <h2>{title} ({meetings.length})</h2>
      {meetings.length === 0 ? (
        <p>{emptyMessage}</p>
      ) : (
        <ul className="meets-scroll-list">
          {meetings.map((m) => (
            <li key={m.id} className="meet-card">
              <h3>{m.title}</h3>
              <p>{m.description}</p>
              <div className="meet-meta">
                <span>Place: {m.place}</span>
                <span>Time: {formatDate(m.time)}</span>
                <span>Capacity: {m.maxCapacity}</span>
              </div>
            </li>
          ))}
        </ul>
      )}
    </section>
  );
}

export default function Account() {
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const [meets, setMeets] = useState([]);
  const [loading, setLoading] = useState(true);

  const userId = user?.id;
  const userName = user?.username || "User";

  useEffect(() => {
    if (!userId) {
  navigate("/login");
  return; 
}

    const controller = new AbortController();

    fetch(`${API_URL}/api/user/${userId}`, { signal: controller.signal })
      .then((res) => (res.ok ? res.json() : Promise.reject(res)))
      .then((data) => setMeets(data.data?.meetups || data.meetups || []))
      .catch((err) => err.name !== "AbortError" && console.error(err))
      .finally(() => setLoading(false));

    return () => controller.abort();
  }, [userId, navigate]);

  const now = new Date().toISOString();
  const activeMeets = meets.filter((m) => m.time >= now);
  const historicalMeets = meets.filter((m) => m.time < now);

  return (
    <div className="account-page">
      <aside className="account-sidebar">
        <div className="account-user-info">
          <div className="account-avatar">
            {userName.charAt(0).toUpperCase()}
          </div>
          <h2>{userName}</h2>
          <span className="account-role">Member</span>
        </div>
        <ToCreateMeetupForm/>
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
        {loading ? (
          <p>Loading your meetings...</p>
        ) : (
          <div className="meets-scroll-container">
            <MeetingSection
              title="Active Meetings"
              meetings={activeMeets}
              emptyMessage="No active meetings."
            />
            <MeetingSection
              title="Historical Meetings"
              meetings={historicalMeets}
              emptyMessage="No historical meetings."
            />
          </div>
        )}
      </main>
    </div>
  );
}