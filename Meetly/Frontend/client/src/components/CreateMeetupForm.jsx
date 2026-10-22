import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createMeetup } from "../api/Api";

export default function CreateMeetupForm() {
  const navigate = useNavigate();
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
        hostId: 4, // tillfälligt
      });
      navigate("/");
    } catch {
      setError("Kunde inte skapa meetup.");
    }
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