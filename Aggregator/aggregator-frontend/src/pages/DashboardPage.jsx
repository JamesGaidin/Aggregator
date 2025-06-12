import React from "react";
import { useNavigate } from "react-router-dom";

const DashboardPage = () => {
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem("token");
        navigate("/", { replace: true });
    };

    return (
        <div className="p-8">
            <h1 className="text-3xl font-bold mb-6">Welcome to the Dashboard!</h1>

            <button
                onClick={handleLogout}
                className="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
            >
                Log Out
            </button>
        </div>
    );
};

export default DashboardPage;
