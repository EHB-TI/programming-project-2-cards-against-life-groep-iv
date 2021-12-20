//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    getAllPG: (callBack) => {
        connectionPool.query(
            'SELECT * FROM PGAnswers; SELECT * FROM PGQuestions',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }
                
                return callBack(null, results);
            }
        )
    },
    getPGByID: (id, callBack) => {
        connectionPool.query(
          `SELECT * FROM PGAnswers where id=?; SELECT * FROM PGQuestions where id=?`,
          [id, id],
          (error, results, fields) => {
            if (error) {
              callBack(error);
            }
            return callBack(null, results);
          }
        );
      },
}