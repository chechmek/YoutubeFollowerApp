import React from 'react';
import axios from 'axios';
import CommentsByWord from './CommentsByWord';

const api = axios.create({
    baseURL: "https://localhost:5000/"
});

function Channel(props) {
    const channel = props.channel;

    let commentsByWord = (id) => {
        const word = document.getElementById('inputWord').value;
        window.open("/commentsbyword/"+id+"/"+word);
        
        console.log(word+id);
    }

    return (
        <>
            {channel ?
                (
                    <div className='col text-center'>

                        <img style={{marginBottom:"20px"}} className='rounded-circle' src={channel.highThumbnail} width="300" height="300" />
                        <h1 style={{marginBottom:"20px"}}>{channel.title}</h1>
                        <div className="d-flex justify-content-center flex-wrap" style={{ marginBottom: "30px" }}>
                            <h6 style={{ marginRight: "80px" }}>Views: {channel.viewCount}</h6>
                            <h6 style={{ marginRight: "80px" }}>Subscribers: {channel.subscriberCount}</h6>
                            <h6 style={{ marginRight: "80px" }}>Videos: {channel.videoCount}</h6>
                        </div>
                        <button className='btn btn-secondary' style={{marginBottom:"20px"}}>Detailed Statistics</button>
                        <div style={{ marginBottom: "100px" }}>{channel.description}</div>
                        
                        <h2>Videos:</h2>
                        <div className="d-flex justify-content-center flex-wrap">
                            {channel.videos.map(vid => {
                                const { id, title, mediumThumbnail } = vid;
                                return (
                                    <a style={{ width: "400px", height: "300px" }} href={"https://www.youtube.com/watch?v=" + id}>
                                        <a >{title}</a>
                                        <img src={mediumThumbnail} height="200" />
                                    </a>)
                            })}
                        </div>

                        <h2>Comments:</h2>
                        <form className='form d-flex justify-content-center' style={{ marginBottom: "50px" }}>
                            <input value="By word" className='btn btn-secondary' onClick={() => commentsByWord(channel.id)} />
                            <input className='form-control' id="inputWord" type="text" style={{ width: '300px' }} placeholder="Word" />
                        </form>
                        <div className="d-flex justify-content-center flex-wrap text-left">
                            {channel.comments.map(com => {
                                const { text, authorName, likeCount } = com;
                                return (
                                    <div className='border border-left border-secondary rounded' style={{ width: "400px", height: "100px", marginBottom:"20px",marginRight:"20px" }} >
                                        <h6 className="text-left">{authorName}</h6>
                                        <div className="text-left">{text}</div>
                                        <div className="text-left">Likes: {likeCount}</div>
                                    </div>)
                            })}
                        </div>
                    </div>
                )
                : <div>loading...</div>
            }
        </>)


}
export default Channel;