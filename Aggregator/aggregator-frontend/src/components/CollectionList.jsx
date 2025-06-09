import React, { useEffect, useState } from 'react';
import axios from 'axios';

const CollectionList = () => {
    const [items, setItems] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:5001/api/CollectionItems') // Use your backend port
            .then(response => {
                setItems(response.data);
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    }, []);

    return (
        <div className="p-6">
            <h2 className="text-2xl font-bold mb-4">Your Collection</h2>
            <table className="min-w-full bg-white border border-gray-200">
                <thead>
                    <tr className="bg-gray-100 text-left">
                        <th className="px-4 py-2">Title</th>
                        <th className="px-4 py-2">Creator</th>
                        <th className="px-4 py-2">Value</th>
                        <th className="px-4 py-2">Location</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(item => (
                        <tr key={item.id} className="border-t">
                            <td className="px-4 py-2">{item.title}</td>
                            <td className="px-4 py-2">{item.creatorName}</td>
                            <td className="px-4 py-2">${item.estimatedValue.toLocaleString()}</td>
                            <td className="px-4 py-2">{item.location}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default CollectionList;
