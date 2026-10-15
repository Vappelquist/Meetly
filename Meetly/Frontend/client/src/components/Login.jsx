import React from "react";

export default function Login(){
    return(
        <>
        <div>
            <input type="text" placeholder="Username" />
            <input type="password" placeholder="Password" />
        </div>
        <div>
            <button type="submit">Login</button>
        </div>
        </>
    );
   
}