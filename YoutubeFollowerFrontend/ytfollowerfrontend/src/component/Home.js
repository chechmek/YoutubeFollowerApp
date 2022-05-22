import React from 'react';
import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:5000/"
});

function Home () {
    api.get('/mainchannel').then(res => {
        console.log(res.data)
    })
//     const url = "https://localhost:5000/repository/allchannels";
// const options = {
//   method: "GET",
//   headers: {
//     Accept: "application/json",
//     "Content-Type": "application/json;charset=UTF-8",
//   }
// };
// fetch(url, options)
//   .then((response) => response.json())
//   .then((data) => {
//     console.log(data);
//   });
        return <h3>home</h3>
            
        
}
export default Home;