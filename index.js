require('dotenv').config();
const express = require('express');
const app = express();
const pool = require("./config/database");
const userRouter = require('./categories/categories.router')


//This is to fix the CORS errors
app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
  });

app.use(express.json());

app.use('/categories',  userRouter);

app.get('/PG', (req, res)=> {
    // source: https://stackoverflow.com/questions/61289125/how-to-retrive-data-from-multiple-tables-using-node-js-and-mysql
    pool.query("SELECT * FROM PGAnswers",(err,rows,fields)=>{
        if(!err){
            pool.query("SELECT * FROM PGQuestions",(errTarn,rowsTarn,fieldsTarn)=>{
                if(!errTarn){
                    res.json({
                      PG :{
                      answers : rows,
                      questions: rowsTarn
                    }});
                }
            }); 
      
        }
        else console.log(err);
      });
})

app.get('/PG13', (req, res)=> {
    // source: https://stackoverflow.com/questions/61289125/how-to-retrive-data-from-multiple-tables-using-node-js-and-mysql
    pool.query("SELECT * FROM PG13Answers",(err,rows,fields)=>{
        if(!err){
            pool.query("SELECT * FROM PG13Questions",(errTarn,rowsTarn,fieldsTarn)=>{
                if(!errTarn){
                    res.json({
                      PG13 :{
                      answers : rows,
                      questions: rowsTarn
                    }});
                }
            }); 
      
        }
        else console.log(err);
      });
})

app.get('/R', (req, res)=> {
    // source: https://stackoverflow.com/questions/61289125/how-to-retrive-data-from-multiple-tables-using-node-js-and-mysql
    pool.query("SELECT * FROM RAnswers",(err,rows,fields)=>{
        if(!err){
            pool.query("SELECT * FROM RQuestions",(errTarn,rowsTarn,fieldsTarn)=>{
                if(!errTarn){
                    res.json({
                      R :{
                      answers : rows,
                      questions: rowsTarn
                    }});
                }
            }); 
        }
        else console.log(err);
      });
})



app.listen(process.env.APP_PORT, ()=>console.log("Listening on port " + process.env.APP_PORT))
