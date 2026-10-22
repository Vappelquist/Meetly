import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createMeetup } from "../api/Api";
import { useAuth } from "../context/AuthContext";

export default function CreateMeetupForm() {
  const navigate = useNavigate();
    const { user } = useAuth();
  const [form, setForm] = useState({
    title: "",
    description: "",
    place: "",
    time: "",
    maxCapacity: 10,
  });
  const [error, setError] = useState("");

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");
    try {
      await createMeetup({
        ...form,
        maxCapacity: Number(form.maxCapacity),
        hostId: user.id
      });
      navigate("/");
    } catch (err) {
console.error("Create meetup failed:", err);
  setError("Kunde inte skapa meetup.");    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input name="title" placeholder="Titel" value={form.title} onChange={handleChange} required />
      <textarea name="description" placeholder="Beskrivning" value={form.description} onChange={handleChange} required />
      <input name="place" placeholder="Plats" value={form.place} onChange={handleChange} required />
      <input name="time" type="datetime-local" value={form.time} onChange={handleChange} required />
      <input name="maxCapacity" type="number" min="1" value={form.maxCapacity} onChange={handleChange} required />
      <button type="submit">Skapa</button>
      {error && <p>{error}</p>}
    </form>
  );
}