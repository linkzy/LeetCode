// components/ListComponent.js
import React, { useState, useEffect } from 'react';
import { fetchListData } from '../utils/api';
import { decodeHtmlEntities } from '../utils/helpers';

const ListComponent = ({ categoryId }) => {
  const [listData, setListData] = useState([]);
  const [selectedItem, setSelectedItem] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const data = await fetchListData(categoryId);
      setListData(data);
    };

    fetchData();
  }, [categoryId]);

  const handleClick = (itemId) => {
    const selected = listData.find((item) => item.id === itemId);
    setSelectedItem(selected);
  };

  return (
    <div style={{ display: 'flex' }}>
      {/* List column */}
      <div style={{ flex: '1', marginRight: '16px' }}>
        <h2>LeetCode Problems</h2>
        <ul>
          {listData.map((item) => (
            <li
              key={item.id}
              onClick={() => handleClick(item.id)}
              style={{ cursor: 'pointer', color: 'blue' }} // Change text color to blue
              dangerouslySetInnerHTML={{ __html: decodeHtmlEntities(item.title.rendered) }}
            />
          ))}
        </ul>
      </div>

      {/* Solution column */}
      {selectedItem && (
        <div style={{ flex: '1' }}>
          <h3>{decodeHtmlEntities(selectedItem.title.rendered)}</h3>
          <div dangerouslySetInnerHTML={{ __html: selectedItem.content.rendered }} />
        </div>
      )}
    </div>
  );
};

export default ListComponent;
