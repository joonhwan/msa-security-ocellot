import { useState } from "react";

const loginUser = async (credentials) => {
    var response = await fetch("https://localhost:7001/connect/token", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded;charset=UTF-8",
        },
        body: `grant_type=password&client_id=mirero.resource.owner.client&username=${credentials.username}&password=${credentials.password}`,
    });
    var data = await response.json();
    return data;
};
const useToken = () => {
    const tokenStorage = localStorage; //sessionStorage;

    const loadToken = () => {
        const tokenString = tokenStorage.getItem("token");
        const token = JSON.parse(tokenString);
        return token;
    };

    const [token, setToken] = useState(loadToken());

    const saveAndSetToken = (token) => {
        tokenStorage.setItem("token", JSON.stringify(token));
        setToken(token);
    };

    return { token, setToken: saveAndSetToken };
};

export default { loginUser, useToken };
export { useToken };
