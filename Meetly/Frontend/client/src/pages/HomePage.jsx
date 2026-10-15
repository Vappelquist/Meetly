import Header from "../components/Header"
import Footer from "../components/Footer"
import MeetingCard from "../components/MeetingCard"

export default function HomePage() {
  // Skapar en lista med 8 element: [0, 1, 2, 3, 4, 5, 6, 7]
  const numberOfCards = Array.from({ length: 8 });

  return (
    <section>
      <Header />

      {/* Container för alla 8 kort */}
      <main className="meeting-grid">
        {numberOfCards.map((_, index) => (
          <MeetingCard key={index} />
        ))}
      </main>

      <Footer />
    </section>
  );
}