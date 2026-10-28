import "../App.css"
import { register } from "../api/Api"
import { useAuth } from "../context/AuthContext"

export default function SignupButton({meetId}){
    const { user } = useAuth();
    
    const handleClick = async () => {
        try{
            await SignUp(meetId, user.id);
        } catch (err) {
            console.error(err)
        }
    };
    if (!user) return null;
    return (
        <button type ="button" className="Signup-Btn" onClick={handleClick}>
            Sign Up
        </button>
    );
}




export function CancelParticipation(){
    return(
        <button className="Cancel-Btn">
            Cancel participation
        </button>
    )
}