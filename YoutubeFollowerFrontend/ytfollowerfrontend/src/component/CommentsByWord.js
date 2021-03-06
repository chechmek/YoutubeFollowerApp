import React, { useEffect, useState } from 'react';
import {
    BrowserRouter as Router,
    useParams
} from "react-router-dom";
import api from '../Helpers/Api';


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
                    <div className="d-flex justify-content-center flex-wrap text-left">
                        {comments.map(com => {
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
            
        </>
    )
}
export default CommentsByWord;