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
    imageUrl:"",
  });
  const LIMITS = {
    title: 50,
    description: 200,
    place: 100
  }
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
        imageUrl: form.imageUrl.trim() || null,
        hostId: user.id
      });
      navigate("/");
    } catch (err) {
console.error("Create meetup failed:", err);
// if (new Date(form.time) < new Date()){
//   setError("The meetup can't be in the past.");
// }
  setError("Couldn't create Meetup:.");    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input name="title" maxLength={LIMITS.title} placeholder="Title" value={form.title} onChange={handleChange} required />
      <textarea name="description" maxLength={LIMITS.description} placeholder="Description" value={form.description} onChange={handleChange} required />
      <small>{form.description.length}/{LIMITS.description}</small>
      <input name="place" maxLength={LIMITS.place} placeholder="Location" value={form.place} onChange={handleChange} required />
      <input name="time" type="datetime-local" value={form.time} onChange={handleChange} required />
      <input name="maxCapacity" type="number" min="1" value={form.maxCapacity} onChange={handleChange} required />
      <input name="imageUrl" type="url" placeholder="Image-Url" value={form.imageUrl} onChange={handleChange} />
      <button type="Submit">Create</button>
      {error && <p>{error}</p>}
    </form>
  );
}