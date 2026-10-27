const API_URL = import.meta.env.VITE_API_URL;

export async function getHealth() {
    const res = await fetch(`${API_URL}/health`);
    if (!res.ok) throw new Error("Request failed");
    return res.text();
}

export async function getMeets(){
    const res = await fetch (`${API_URL}/api/meetups`)
    if (!res.ok) throw new Error("Request failed");
    return res.json();
}

export async function apiFetchCall(apiCall){
    const res = await fetch(`${API_URL}/api/${apiCall}`)
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
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    });
    if (!res.ok) throw new Error("Request failed");
    return res.json();
}

export async function SignUp(meetId, id){
    const res = await fetch(`${API_URL}/api/meetups/${meetId}/register/${id}`, {
        method: "POST",
    });
    if (!res.ok) throw new Error("Request failed");
    return res.json();
}

export async function deleteMeetup(id){
    const res = await fetch(`${API_URL}/api/meetups/Delete/${id}`, {
        method: "DELETE",
    });
    if (!res.ok) throw new Error("Request failed");
}