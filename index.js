require('dotenv').config();
const express = require('express');
const app = express();
// const connectionPool = require("./config/database");
const getPG = require('./categories/pg.router');
const getPG13 = require('./categories/pg13.router');
//This is to fix the CORS errors
app.use(function (req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});

app.use(express.json());

app.use("/pg", getPG);
app.use("/pg13", getPG13);



app.listen(process.env.APP_PORT, () => console.log("Listening on port " + process.env.APP_PORT))