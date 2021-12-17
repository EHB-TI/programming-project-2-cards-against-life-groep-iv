const pool = require("../config/database");

module.exports = {
    create: (data,callback) => {
        pool.query(
            'insert into PG(question, answer) VALUES (?,?)',
            [
                data.question,
                data.answer 
            ],
            (error, results, fields)=> {
                if(error){
                    return callback(error);
                }
                return callback(null, results);
            }
        )
    }
};