const API_URL = import.meta.env.VITE_API_URL;

export async function getHealth() {
    const res = await fetch(`${API_URL}/health`);
    if (!res.ok) throw new Error("Request failed");
    return res.text();
}