// api.js
import axios from 'axios';

const apiUrl = process.env.REACT_APP_API_URL;

export const fetchListData = async (categoryId) => {
  try {
    const response = await axios.get(`${apiUrl}/?categories=${categoryId}&orderby=title&order=asc`);
    return response.data;
  } catch (error) {
    console.error('Error fetching list data:', error);
    return [];
  }
};