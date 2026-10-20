import Header from "../components/Header"
import Footer from "../components/Footer"
import MeetingCard from "../components/MeetingCard"

export default function HomePage() {
  const numberOfCards = Array.from({ length: 8 });

  return (
    <section>
      <Header />

      <main className="meeting-grid">
        {numberOfCards.map((_, index) => (
          <MeetingCard key={index} />
        ))}
      </main>

      <Footer />
    </section>
  );
}