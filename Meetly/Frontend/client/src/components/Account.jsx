import React, { useState, useEffect } from "react";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import { apiFetchCall } from "../api/Api";

const API_URL = import.meta.env.VITE_API_URL;

export default function Account() {
    // Bara hämtar lite skit
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const [meets, setMeets] = useState([]);
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

        loadMeetups();

        return () => {
            ignore = true;
        };
    }, [userId]);

  const formatDate = (dateString) => {
    return new Date(dateString).toLocaleDateString("en-US", {
      month: "short",
      day: "numeric",
      year: "numeric",
      hour: "2-digit",
      minute: "2-digit",
    });
    };

    async function handleCancelAttendance(meetupId) {
        if (!userId) {
            return;
        }

        setCancellingMeetupId(meetupId);
        setErrorMessage("");

        try {
            const response = await fetch(
                `${API_URL}/api/meetups/${meetupId}/register/${userId}`,
                {
                    method: "DELETE"
                }
            );

            if (!response.ok) {
                throw new Error("Could not cancel attendance.");
            }

            setMeets((currentMeets) =>
                currentMeets.filter((meet) => meet.id !== meetupId)
            );
        } catch (error) {
            console.error(error);
            setErrorMessage("Could not cancel attendance. Please try again.");
        } finally {
            setCancellingMeetupId(null);
        }
    }

  return (
    <div className="account-page">
      <aside className="account-sidebar">
        <div className="account-user-info">
                  <div className="account-avatar">
                      {user?.username?.charAt(0).toUpperCase() || "?"}
                  </div>

                  <h2>{user?.username || "Guest"}</h2>
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
              {errorMessage && (
                  <p role="alert">{errorMessage}</p>
              )}

        {!userId ? (
            <p>Please log in to see your meetups.</p>
        ) : loading ? (
            <p>Loading meetups...</p>
        ) : errorMessage && meets.length === 0 ? (
            null
        ) : meets.length === 0 ? (
            <p>You have not joined any meetups yet.</p>
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
                      <button
                          type="button"
                          className="cancel-attendance-btn"
                          onClick={() => handleCancelAttendance(meet.id)}
                          disabled={cancellingMeetupId !== null}
                      >
                          {cancellingMeetupId === meet.id
                              ? "Cancelling..."
                              : "Cancel attendance"}
                      </button>
                </li>
              ))}
            </ul>
          </div>
        )}
      </main>
    </div>
  );
}