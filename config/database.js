const { createPool } = require('mysql');

const pool = createPool({
    port:process.env.DBPORT,
    host:process.env.HOST,
    user:process.env.USER,
    password:process.env.PASSWORD,
    database: process.env.DATABASE
})

module.exports = pool;