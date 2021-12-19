//Author: De Vogel Ryan
const { createPool } = require('mysql');

//process.env get's the variables out of the .env file
const connectionPool = createPool({
    multipleStatements: true,
    port:process.env.DBPORT,
    host:process.env.HOST,
    user:process.env.USER,
    password:process.env.PASSWORD,
    database: process.env.DATABASE
})



module.exports = connectionPool;