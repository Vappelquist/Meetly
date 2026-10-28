import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createMeetup } from "../api/Api";
import { useAuth } from "../context/AuthContext";

export default function CreateMeetupForm() {
  const navigate = useNavigate();
  const { user, isLoggedIn } = useAuth();

  const [form, setForm] = useState({
    title: "",
    description: "",
    place: "",
    time: "",
    maxCapacity: 10,
    imageUrl: "",
  });

  const LIMITS = {
    title: 50,
    description: 200,
    place: 100,
  };

  const [error, setError] = useState("");

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    if (!isLoggedIn || !user) {
      setError("You must be logged in to create a meetup.");
      navigate("/login");
      return;
    }

    try {
      await createMeetup({
        ...form,
        maxCapacity: Number(form.maxCapacity),
        imageUrl: form.imageUrl.trim() || null,
        hostId: user.id,
      });
      navigate("/");
    } catch (err) {
      console.error("Create meetup failed:", err);
      setError(err.message || "Couldn't create meetup.");
    }
  };

  return (
    <form className="createmeetup-form" onSubmit={handleSubmit}>
      <label className="createmeetup-field">
        <span>Title</span>
        <input name="title" maxLength={LIMITS.title} placeholder="Title" value={form.title} onChange={handleChange} required />
      </label>

      <label className="createmeetup-field">
        <span>Description</span>
        <textarea name="description" rows={4} maxLength={LIMITS.description} placeholder="Description" value={form.description} onChange={handleChange} required />
        <small className="createmeetup-counter">{form.description.length}/{LIMITS.description}</small>
      </label>

      <label className="createmeetup-field">
        <span>Location</span>
        <input name="place" maxLength={LIMITS.place} placeholder="Location" value={form.place} onChange={handleChange} required />
      </label>

      <div className="createmeetup-row">
        <label className="createmeetup-field">
          <span>Time</span>
          <input name="time" type="datetime-local" value={form.time} onChange={handleChange} required />
        </label>
        <label className="createmeetup-field">
          <span>Max Capacity</span>
          <input name="maxCapacity" type="number" min="1" value={form.maxCapacity} onChange={handleChange} required />
        </label>
      </div>

      <label className="createmeetup-field">
        <span>Image URL (Optional)</span>
        <input name="imageUrl" type="url" placeholder="Image-Url" value={form.imageUrl} onChange={handleChange} />
      </label>

      <button type="submit" className="createmeetup-submit">Create</button>
      {error && <p className="createmeetup-error" style={{ color: "red" }}>{error}</p>}
    </form>
  );
}