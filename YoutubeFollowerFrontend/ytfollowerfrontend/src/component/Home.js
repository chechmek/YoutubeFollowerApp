import React, { useEffect, useState } from 'react';
import api from '../Helpers/Api';
import Channel from './Channel';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';

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