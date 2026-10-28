const API_URL = import.meta.env.VITE_API_URL;

function getAuthHeaders() {
    try {
        const stored = localStorage.getItem("user");
        const user = stored ? JSON.parse(stored) : null;
        return user?.token ? { Authorization: `Bearer ${user.token}` } : {};
    } catch {
        return {};
    }
}

export async function getHealth() {
    const res = await fetch(`${API_URL}/health`);
    if (!res.ok) throw new Error("Request failed");
    return res.text();
}

export async function getMeets() {
    const res = await fetch(`${API_URL}/api/meetups`);
    if (!res.ok) throw new Error("Request failed");
    return res.json();
}

export async function apiFetchCall(apiCall) {
    const res = await fetch(`${API_URL}/api/${apiCall}`, {
        headers: {
            ...getAuthHeaders(),
        },
    });
    if (!res.ok) throw new Error("Request failed");
    return res.json();
}

export async function getMeetById(id, signal) {
    const res = await fetch(`${API_URL}/api/meetups/${id}`, { signal });
    if (!res.ok) throw new Error("Request failed");
    return res.json();
}

export async function createMeetup(data) {
    const res = await fetch(`${API_URL}/api/meetups`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            ...getAuthHeaders(),
        },
        body: JSON.stringify(data),
    });
    if (!res.ok) {
        const message = await res.text();
        throw new Error(message || "Request failed");
    }
    return res.json();
}

export async function register(name, password) {
    const res = await fetch(`${API_URL}/api/Auth/register`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ name, password }),
    });

    if (!res.ok) {
        const errorData = await res.json().catch(() => null);
        const message = Array.isArray(errorData) ? errorData.join(", ") : await res.text();
        throw new Error(message || "Registration failed");
    }

    return res.json().catch(() => ({}));
}

export async function login(username, password) {
    const res = await fetch(`${API_URL}/api/Auth/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ Username: username, Password: password }),
    });

    if (!res.ok) {
        const message = await res.text();
        throw new Error(message || "Login failed");
    }

    return res.json();
}

export async function registerForMeetup(meetupId) {
    const res = await fetch(`${API_URL}/api/meetups/${meetupId}/register/0`, {
        method: "POST",
        headers: {
            ...getAuthHeaders(),
        },
    });
    if (!res.ok) {
            const message = await res.text();
        throw new Error(message || "Registration failed");
    }
    return res.text();
}

export async function cancelAttendance(meetupId) {
    const res = await fetch(`${API_URL}/api/meetups/${meetupId}/register`, {
        method: "DELETE",
        headers: { ...getAuthHeaders() },
    });
    if (!res.ok) {
        const message = await res.text();
        throw new Error(message || "Could not cancel attendance");
    }
}

export async function deleteMeetup(id) {
    const res = await fetch(`${API_URL}/api/meetups/Delete/${id}`, {
        method: "DELETE",
        headers: {
            ...getAuthHeaders(),
        },
    });
    if (!res.ok) throw new Error("Request failed");
}

export const SignUp = registerForMeetup;