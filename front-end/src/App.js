import React from 'react';
import ListComponent from './components/ListComponent';

const App = () => {
  return (
    <div>
      <h1>My React LeetCode Showcase</h1>
      <ListComponent categoryId={22} />
      <ListComponent categoryId={13} />
    </div>
  );
};

export default App;