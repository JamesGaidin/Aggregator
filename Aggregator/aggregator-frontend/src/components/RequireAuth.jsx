import React from "react";
import { Navigate } from "react-router-dom";
import jwtDecode from "jwt-decode";

const RequireAuth = ({ children }) => {
    const token = localStorage.getItem("token");

    if (!token) {
        return <Navigate to="/" replace />;
    }

    try {
        const decoded = jwtDecode(token);
        const isExpired = decoded.exp * 1000 < Date.now();

        if (isExpired) {
            localStorage.removeItem("token");
            return <Navigate to="/" replace />;
        }
    } catch (error) {
        // Invalid token format
        localStorage.removeItem("token");
        return <Navigate to="/" replace />;
    }

    return children;
};

export default RequireAuth;
