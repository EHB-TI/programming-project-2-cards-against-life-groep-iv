const pool = require("../config/database");

module.exports = {
        create: (data, callback) => {
                pool.query(
                    'insert into CommunityAnswers(answer) VALUES (?)',
                    [
                        data.answer
                    ],
                    (error, results, fields) => {
                        if (error) {
                            return callback(error);
                        }
                        pool.query(
                            'insert into CommunityQuestions(question) VALUES (?)',
                            [
                                data.question
                            ],
                            (error, results, fields) => {
                                if (error) {
                                    return callback(error);
                                }
                                return callback(null, results);
                            })
                        return callback(null, results);
                

                    }
                )}
    }
