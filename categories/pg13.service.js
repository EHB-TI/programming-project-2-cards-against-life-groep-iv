const connectionPool = require("../config/database");

module.exports = {
    getAllPG13: (callBack) => {
        connectionPool.query(
            'SELECT * FROM PG13Answers; SELECT * FROM PG13Questions',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }
                
                return callBack(null, results);
            }
        )
    },
    getPG13ByID: (id, callBack) => {
        connectionPool.query(
          `SELECT * FROM PG13Answers where id=?; SELECT * FROM PG13Questions where id=?`,
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