import React, { useState, useEffect } from "react";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import ToCreateMeetupForm from "../components/ToCreateMeetupForm";
import { getMeets } from "../api/Api";
import { deleteMeetup } from "../api/Api";

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

function MeetingSection({ title, meetings, emptyMessage, onDelete }) {
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
              {onDelete &&(
                <button
                  type="button"
                  className = "meet-delete-btn"
                  onClick={() => onDelete(m.id)}
                    >
                    Delete
                    </button>

              )}
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
  const [hosted, setHosted] = useState([])
  const [loading, setLoading] = useState(true);
    const [errorMessage, setErrorMessage] = useState("");
    const [cancellingMeetupId, setCancellingMeetupId] = useState(null);

    const userId = user?.id;

    useEffect(() => {
        if (!userId) {
            return;
        }

        let ignore = false;

        async function loadMeetups() {
            try {
                const account = await apiFetchCall(`user/${userId}`);

                if (!ignore) {
                    setMeets(account.meetups);
                    setErrorMessage("");
                }
            } catch (error) {
                if (!ignore) {
                    console.error(error);
                    setErrorMessage("Could not load your meetups.");
                }
            } finally {
                if (!ignore) {
                    setLoading(false);
                }
            }
        }

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

useEffect(() => {
  if (!userId) return;

  getMeets()
  .then((all) => setHosted(all.filter((m) => m.hostId === userId)))
  .catch((err) => console.error(err));
}, [userId])

  const now = new Date().toISOString();
  const activeMeets = meets.filter((m) => m.time >= now);
  const historicalMeets = meets.filter((m) => m.time < now);
  const activeHosted = hosted.filter((m) => new Date(m.time) >= new Date());
  const PreviousHosted = hosted.filter((m) => new Date(m.time) <= new Date());
  const handleDelete = async (id) => {
    if (!window.confirm("Delete this meetup?")) return;
    try {
      await deleteMeetup(id);
      setHosted((prev) => prev.filter((m) => m.id !== id))
      setMeets((prev) => prev.filter((m) => m.id !== id))
    } catch (err) {
      console.error(err)
    }
  }


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
              title="Active Hosted Meetings"
              meetings={activeHosted}
              empty ="No active meetings"
              onDelete={handleDelete}
            />

            <MeetingSection
              title="Previous Hosted Meetings"
              meetings={PreviousHosted}
              empty ="No active meetings"
              onDelete={handleDelete}
            />


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
);
