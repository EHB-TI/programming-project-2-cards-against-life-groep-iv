require('dotenv').config();
const express = require('express');
const app = express();
const pool = require("./config/database");
const userRouter = require('./categories/categories.router')

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
  });

app.use(express.json());


app.use('/categories',  userRouter);

app.get('/', (req, res)=> {
    pool.query(
            'SELECT * FROM PGanswer UNION SELECT * FROM PGquestion ',
            (err, rows, field)=> {
                if(!err){
                        res.json(rows);
                }
                else { 
                    res.send(err);
                }
            }
    )
})


app.listen(process.env.APP_PORT, ()=>console.log("Listening on port " + process.env.APP_PORT))
