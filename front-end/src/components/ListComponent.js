// components/ListComponent.js
import React, { useState, useEffect } from 'react';
import { fetchListData } from '../utils/api';
import { decodeHtmlEntities } from '../utils/helpers'; // Import the decoding function

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
    <div className="container mx-auto p-4">
      <h2 className="text-2xl font-bold mb-4">LeetCode Problems</h2>
      <ul className="list-disc pl-4">
        {listData.map((item) => (
          <li
            key={item.id}
            onClick={() => handleClick(item.id)}
            className="cursor-pointer hover:underline mb-2"
            dangerouslySetInnerHTML={{ __html: decodeHtmlEntities(item.title.rendered) }}
          />
        ))}
      </ul>

      {selectedItem && (
        <div className="mt-8">
          <h3 className="text-xl font-bold mb-4">{decodeHtmlEntities(selectedItem.title.rendered)}</h3>
          <div dangerouslySetInnerHTML={{ __html: selectedItem.content.rendered }} />
        </div>
      )}
    </div>
  );
};

export default ListComponent;
