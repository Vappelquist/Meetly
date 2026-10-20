import React from "react";

export default function Login() {
    return (
        <>
            <div className="login-card">
                <input type="text" placeholder="Username" />
                <input type="password" placeholder="Password" />
                <button type="submit" className="login-submit-btn">Login</button>
            </div>
        </>
    );
}