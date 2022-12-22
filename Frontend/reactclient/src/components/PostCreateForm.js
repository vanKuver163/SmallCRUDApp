import React, { useState } from 'react'
import Constants from '../utilities/Constants'

export default function PostCreateForm(props) {

    const initialFormData = Object.freeze({
        title: "Post x",
        content: "This is post x."
    });

    const [formData, setFormData] = useState(initialFormData);



    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        })
    };

    const handleSubmit = (e) => {

        const postToCreate = {
            postId: 0,
            title: formData.title,
            content: formData.content
        };

        const url = Constants.API_URL_GET_ALL_POSTS;

        fetch(url, {
            method: 'POST',
            body: JSON.stringify(postToCreate),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
            },
        })
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
            })
            .catch((err) => {
                console.log(err.message);
            });
        props.onPostCreated(postToCreate);
    }

    return (
        <form className='W-100 px-5'>
            <h1 className='mt-5'>Create new post</h1>
            <div className='mt-5'>
                <label className="h3 form-label">Post title</label>
                <input value={formData.title} name="title" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className='mt-4'>
                <label className="h3 form-label">Post content</label>
                <input value={formData.content} name="content" type="text" className="form-control" onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}
