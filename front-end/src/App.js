import React from 'react';
import ListComponent from './components/ListComponent';

const App = () => {
  // Assume problems is an array of LeetCode problems
  const problems = [
    { id: 1, title: 'Two Sum' },
    { id: 2, title: 'Add Two Numbers' },
    // ... other problems
  ];

  return (
    <div>
      <h1>My React LeetCode Showcase</h1>
      <ListComponent problems={problems} />
    </div>
  );
};

export default App;