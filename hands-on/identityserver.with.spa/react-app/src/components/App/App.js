//import { useState } from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import "./App.css";
import Dashboard from "../Dashboard";
import Preferences from "../Preferences";
import Login from "../Login";
import { useToken } from "../../services/auth";

const App = () => {
    const { token, setToken } = useToken();
    if (!token) {
        console.log("no token!");
        return <Login setToken={setToken} />;
    }
    console.log("got token !: ", token);

    return (
        <div className="wrapper">
            <h2>App</h2>
            <BrowserRouter>
                <Switch>
                    <Route path="/dashboard">
                        <Dashboard />
                    </Route>
                    <Route path="/preferences">
                        <Preferences />
                    </Route>
                </Switch>
            </BrowserRouter>
        </div>
    );
};
export default App;
