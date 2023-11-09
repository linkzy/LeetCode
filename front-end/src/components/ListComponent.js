
import React, { useState, useEffect } from 'react';
import { fetchListData } from '../utils/api';

const ListComponent = ({ categoryId }) => {
  // State to store the list of LeetCode problems
  const [listData, setListData] = useState([]);

  // State to store the selected item when clicked
  const [selectedItem, setSelectedItem] = useState(null);

  // useEffect hook to fetch data when the component mounts or categoryId changes
  useEffect(() => {
    const fetchData = async () => {
      const data = await fetchListData(categoryId);
      setListData(data);
    };

    fetchData();
  }, [categoryId]);

  // Event handler for handling item clicks
  const handleClick = (itemId) => {
    // Find the selected item based on the clicked item's ID
    const selected = listData.find((item) => item.id === itemId);
    setSelectedItem(selected);
  };

  return (
    <div>
      {/* Display the list of LeetCode problems */}
      <h2>LeetCode Problems</h2>
      <ul>
        {listData.map((item) => (
          // Attach the handleClick event to each list item
          <li key={item.id} onClick={() => handleClick(item.id)}>
            {item.title.rendered}
          </li>
        ))}
      </ul>

      {/* Display the selected item's content if an item is selected */}
      {selectedItem && (
        <div>
          <h3>{selectedItem.title.rendered}</h3>
          <div dangerouslySetInnerHTML={{ __html: selectedItem.content.rendered }} />
        </div>
      )}
    </div>
  );
};

export default ListComponent;
