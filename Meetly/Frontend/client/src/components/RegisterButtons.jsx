import { useEffect, useState } from "react";
import "../App.css";
import { apiFetchCall, registerForMeetup, cancelAttendance } from "../api/Api";
import { useAuth } from "../context/AuthContext";

export default function AttendanceButton({ meetId }) {
    const { user } = useAuth();
    const [attending, setAttending] = useState(null);
    const [busy, setBusy] = useState(false);
    const [error, setError] = useState("");

    useEffect(() => {
        if (!user?.id) return;

        apiFetchCall(`user/${user.id}`)
            .then((data) => {
                const meets = data.data?.meetups || data.meetups || [];
                setAttending(meets.some((m) => m.id === Number(meetId)));
            })
            .catch((err) => console.error(err));
    }, [user?.id, meetId]);

    const handleClick = async () => {
        setBusy(true);
        setError("");
        try {
            if (attending) {
                await cancelAttendance(meetId);
                setAttending(false);
            } else {
                await registerForMeetup(meetId);
                setAttending(true);
            }
        } catch (err) {
            setError(err.message);
        } finally {
            setBusy(false);
        }
    };

    if (!user || attending === null) return null;

    return (
        <>
            <button
                type="button"
                className={attending ? "Cancel-Btn" : "Signup-Btn"}
                onClick={handleClick}
                disabled={busy}
            >
                {attending ? "Cancel participation" : "Sign Up"}
            </button>
            {error && <p className="createmeetup-error">{error}</p>}
        </>
    );
}