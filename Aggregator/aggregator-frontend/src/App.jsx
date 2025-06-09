import React from 'react';
import CollectionList from './components/CollectionList';

function App() {
    return (
        <div className="min-h-screen bg-gray-50">
            <header className="bg-green-700 text-white p-4 text-2xl font-bold">
                🐊 Aggregator
            </header>
            <main>
                <CollectionList />
            </main>
        </div>
    );
}

export default App;
