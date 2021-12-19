//Author: De Vogel Ryan
//Source: https://github.com/Tariqu/REST_API_WITH_MYSQL I use this in the wole API

require('dotenv').config();
const express = require('express');
const cors = require('cors');
const app = express();
app.use(cors())
const getPG = require('./categories/pg.router');
const getPG13 = require('./categories/pg13.router');
const getR = require('./categories/r.router');
const getRoom = require('./rooms/rooms.router');
const getUser = require('./users/user.router');
const getStats = require('./stats/stat.router');

//This is to fix the CORS errors
//This way a local client can do a get request.
app.use(function (req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    //res.header("Access-Control-Allow-Origin: http://localhost:8080")
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});

//This is needed so client can post json data
app.use(express.json());

//categories
app.use("/pg", getPG);
app.use("/pg13", getPG13);
app.use("/r", getR);

//Rooms
app.use("/rooms", getRoom);

//Users
app.use("/users", getUser);

//Stats
app.use("/stats", getStats);

//This get's the port out of the .env file
app.listen(process.env.APP_PORT, () => console.log("Listening on port " + process.env.APP_PORT))