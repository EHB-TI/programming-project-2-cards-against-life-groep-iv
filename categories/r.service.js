//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    getAllR: (callBack) => {
        connectionPool.query(
            'SELECT * FROM RAnswers; SELECT * FROM RQuestions',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }
                
                return callBack(null, results);
            }
        )
    },
    getRByID: (id, callBack) => {
        connectionPool.query(
          `SELECT * FROM RAnswers where id=?; SELECT * FROM RQuestions where id=?`,
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