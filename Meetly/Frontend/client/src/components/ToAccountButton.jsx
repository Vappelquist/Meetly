import { useNavigate } from "react-router-dom";

export default function ToAccountButton(){
      const navigate = useNavigate();

    return (
        <button className="BackButton-class" onClick={() => navigate("/Account")}>
            Account
        </button>
    );
}