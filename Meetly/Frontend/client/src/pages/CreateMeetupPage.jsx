import CreateMeetupForm from "../components/CreateMeetupForm";
import Footer from "../components/Footer";
import Header from "../components/Header";


export default function CreateMeetupPage() {
    return (
        <section>
            <Header />
            <main>
                <h1>Create meetup</h1>
                <CreateMeetupForm />
            </main>
            <Footer />
        </section>
    );
}