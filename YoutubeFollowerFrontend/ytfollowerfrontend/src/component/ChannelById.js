import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Channel from './Channel';
import 'react-multi-carousel/lib/styles.css';
import {
    BrowserRouter as Router,
    useParams
  } from "react-router-dom";

const api = axios.create({
    baseURL: "https://localhost:5000/"
});

function ChannelById() {
    const [channelData, setChannel] = useState();
    let { id } = useParams();
    console.log(id);
    
    useEffect(() => {
        if (channelData === undefined || channelData === null) {

            api.get('/Channel?id='+id).then(res => {
                setChannel(res.data);
            });
            //console.log("i ask your api")

        }
    }, []);

    console.log(channelData);

    
    return <Channel channel={channelData}/>

    

}
export default ChannelById;