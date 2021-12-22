//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    getAllCommunity: (callBack) => {
        connectionPool.query(
            'SELECT * FROM CommunityAnswers; SELECT * FROM CommunityQuestions',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }

                return callBack(null, results);
            }
        )
    },
    getCommunityByID: (id, callBack) => {
        connectionPool.query(
            `SELECT * FROM CommunityAnswers where id=?; SELECT * FROM CommunityQuestions where id=?`,
            [id, id],
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }
                return callBack(null, results);
            }
        );
    },
    //This is for checking for a duplicate value
    //source: https://www.titanwolf.org/Network/q/73afed53-5543-4927-bd51-8d4bb977ecf0/y
    createCommunity: (data, callBack) => {
        console.log(data.answer);
        console.log(data.question);
        connectionPool.query('INSERT INTO CommunityAnswers(answer) VALUES (?)',
            [data.answer],
            function (err, rows) {
                if (err) {
                    callBack(err);
                }
                connectionPool.query(
                    'INSERT INTO CommunityQuestions(question) VALUES (?)',
                    [
                        data.question,
                    ],
                    (error, results, fields) => {
                        if (error) {
                            callBack(error);
                        }

                        return callBack(null, results);
                    }
                )
            })
    },
}