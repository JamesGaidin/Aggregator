import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

const RegisterPage = () => {
    const [formData, setFormData] = useState({
        userName: "",
        email: "",
        password: "",
        confirmPassword: "",
    });
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleRegister = async (e) => {
        e.preventDefault();
        setError("");

        if (formData.password !== formData.confirmPassword) {
            setError("Passwords do not match.");
            return;
        }

        try {
            await axios.post("http://localhost:5000/api/auth/register", {
                userName: formData.userName,
                email: formData.email,
                password: formData.password,
            });

            // Registration successful → go to login
            navigate("/");
        } catch (err) {
            setError(err.response?.data?.message || "Registration failed.");
        }
    };

    return (
        <div className="flex justify-center items-center h-screen bg-gray-100">
            <form onSubmit={handleRegister} className="bg-white p-8 rounded shadow-md w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">Create an Account</h2>

                {error && <p className="text-red-500 mb-4 text-center">{error}</p>}

                <input
                    name="userName"
                    type="text"
                    placeholder="Username"
                    value={formData.userName}
                    onChange={handleChange}
                    className="w-full mb-4 p-2 border rounded"
                    required
                />
                <input
                    name="email"
                    type="email"
                    placeholder="Email"
                    value={formData.email}
                    onChange={handleChange}
                    className="w-full mb-4 p-2 border rounded"
                    required
                />
                <input
                    name="password"
                    type="password"
                    placeholder="Password"
                    value={formData.password}
                    onChange={handleChange}
                    className="w-full mb-4 p-2 border rounded"
                    required
                />
                <input
                    name="confirmPassword"
                    type="password"
                    placeholder="Confirm Password"
                    value={formData.confirmPassword}
                    onChange={handleChange}
                    className="w-full mb-6 p-2 border rounded"
                    required
                />

                <button type="submit" className="w-full bg-green-600 text-white p-2 rounded hover:bg-green-700">
                    Register
                </button>
            </form>
            <p className="text-center mt-4">
                Already have an account? <a href="/" className="text-blue-600">Login</a>
            </p>
        </div>
    );
};

export default RegisterPage;
