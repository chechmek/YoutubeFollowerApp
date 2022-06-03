import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:5000/"//"https://youtubefollowerapi.azurewebsites.net/"
  });

export default api ;