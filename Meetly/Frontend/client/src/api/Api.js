const API_URL = import.meta.env.VITE_API_URL;

export async function getHealth() {
    const res = await fetch(`${API_URL}/health`);
    if (!res.ok) throw new Error("Request failed");
    return res.text();
}

export async function getMeets(){
    const res = await fetch (`${API_URL}/api/meetups`)
    if (!res.ok) throw new Error("Request failed");
    return res.text();
}

export async function apiFetchCall(apiCall){
    const res = await fetch(`${API_URL}/api/${apiCall}`)
    if (!res.ok) throw new Error("Request failed");
    return res.text();  
}