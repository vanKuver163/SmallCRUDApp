const API_BASE_URL_DEVELOPMENT = 'https://localhost:5001';
const API_BASE_URL_PRODUCTION = 'https://appname.azurewebsites.net';



const ENDPOINTS={
    GET_ALL_POSTS: 'Posts' 
};

const development = {
    API_URL_GET_ALL_POSTS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_POSTS}`
};

const production ={
    API_URL_GET_ALL_POSTS: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_POSTS}`
}

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
