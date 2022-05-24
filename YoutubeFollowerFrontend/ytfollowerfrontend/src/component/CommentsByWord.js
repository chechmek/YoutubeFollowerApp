import React, { useEffect, useState } from 'react';
import {
    BrowserRouter as Router,
    useParams
} from "react-router-dom";
import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:5000/"
});

function CommentsByWord() {
    const [comments, setComments] = useState();
    let { word } = useParams();
    let { id } = useParams();

    useEffect(() => {
        if (comments === undefined || comments === null) {
            api.get('/CommentsByWord?channelId=' + id + "&word=" + word).then((res) => {

                setComments(res.data);
            });
        };
    }, []);

    console.log(comments);

    return (
        <>
            {comments ? (
                <div>


                    <h1>Comments with word: {word}</h1>
                    <div>
                        {comments.map(com => {
                            const { text, authorName, likeCount } = com;
                            return (
                                <div style={{ width: "400px", height: "300px" }} >
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
            
        </>
    )
}
export default CommentsByWord;