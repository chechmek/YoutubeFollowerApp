import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Channel from './Channel';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';

const api = axios.create({
    baseURL: "https://localhost:5000/"
});

function Home() {
    const [channelData, setChannel] = useState();
    useEffect(() => {
        if (channelData === undefined || channelData === null) {

            api.get('/mainchannel').then(res => {
                setChannel(res.data);
            });
            //console.log("i ask your api")

        }
    }, []);

    console.log(channelData);

    
        return <Channel channel={channelData}/>

    

}
export default Home;