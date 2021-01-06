import PropTypes from "prop-types";
import { useState } from "react";
import "./Login.css";
import auth from "../../services/auth";

const Login = ({ setToken }) => {
    const [credentials, setCredentials] = useState({
        username: "",
        password: "",
    });

    const handleLogin = async (e) => {
        e.preventDefault();
        const authData = await auth.loginUser(credentials);
        console.log("login response : ", authData);
        setToken(authData);
    };

    return (
        <div className="login-wrapper">
            <form onSubmit={handleLogin}>
                <label>
                    <p>Username</p>
                    <input
                        type="text"
                        onChange={(e) =>
                            setCredentials({
                                ...credentials,
                                username: e.target.value,
                            })
                        }
                    />
                </label>
                <label>
                    <p>Password</p>
                    <input
                        type="password"
                        onChange={(e) =>
                            setCredentials({
                                ...credentials,
                                password: e.target.value,
                            })
                        }
                    />
                </label>
                <div>
                    <button type="submit">Submit</button>
                </div>
            </form>
        </div>
    );
};
Login.propTypes = {
    setToken: PropTypes.func.isRequired,
};

export default Login;
