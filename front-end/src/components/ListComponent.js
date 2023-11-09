import React from 'react';

const ListComponent = ({ problems }) => {
  return (
    <div>
      <h2>LeetCode Problems</h2>
      <ul>
        {problems.map((problem) => (
          <li key={problem.id}>{problem.title}</li>
        ))}
      </ul>
    </div>
  );
};

export default ListComponent;