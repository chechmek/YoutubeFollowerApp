import React, { useState, useEffect } from 'react';
import { FormGroup, FormControl } from 'react-bootstrap';
import api from '../Helpers/Api';


function Other() {
    const [channels, setChannels] = useState();

    let starChannel = (id) => {
        console.log(id);
        api.post('/repository/star?id=' + id).then(() => {
            window.location.reload();
        });
    }
    let addChannel = () => {
        const id = document.getElementById('inputChannelId').value;
        console.log(id);
        api.post('/repository/addchannel?id=' + id).then(() => {
            window.location.reload();
        });
    }
    let removeChannel = (id) => {
        console.log(id);
        api.delete('/repository/removechannel?id=' + id).then(() => {
            window.location.reload();
        });
    }

    useEffect(() => {
        if (channels === undefined || channels === null) {
            api.get('/repository/allchannels').then(res => {
                setChannels(res.data);
            });
        }
    }, []);

    return (<>
        {channels ? (
            <div style={{ width: '500px' }}>
                <form className='form d-flex justify-content-center' style={{marginBottom:"50px"}}>
                    <input value="Add channel" className='btn btn-secondary' onClick={addChannel} />
                    <input className='form-control' id="inputChannelId" type="text" style={{ width: '300px' }} placeholder="Copy channel ID from youtube URL" />
                </form>
                <div>
                    <h3>Your channels</h3>
                    {channels.map(ch => {
                        const { id, name, isStared } = ch;
                        return (
                            <div className='d-flex justify-content-between' style={{marginBottom:"5px"}}>
                                <a href={"channel/" + id}>{name}</a>
                                <div>
                                    {isStared ? <div style={{marginRight:"20px"}} className='btn btn-warning'>Starred</div> : ""}
                                    {isStared ? "" : <button style={{marginRight:"20px"}} className='btn btn-secondary' onClick={() => starChannel(id)}>Star</button>}
                                    <button onClick={() => removeChannel(id)} className='btn btn-danger'>Remove</button>
                                </div>
                            </div>
                        )
                    })}
                </div>
            </div>
        )
            : <div>loading...</div>}
    </>)
}
export default Other;