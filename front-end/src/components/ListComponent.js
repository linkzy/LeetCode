import React, { useState, useEffect } from 'react';
import { fetchListData } from '../utils/api';

const ListComponent = ({ categoryId }) => {
  const [listData, setListData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const data = await fetchListData(categoryId);
      setListData(data);
    };

    fetchData();
  }, [categoryId]);

  return (
    <div>
      <h2>List</h2>
      <ul>
        {listData.map((item) => (
          <li key={item.id}>{item.title.rendered}</li>
        ))}
      </ul>
    </div>
  );
};

export default ListComponent;