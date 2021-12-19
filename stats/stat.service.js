//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    getAllStats: (callBack) => {
        connectionPool.query(
            'SELECT * FROM Stats;',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }

                return callBack(null, results);
            }
        )
    },
    getStatByUserID: (id, callBack) => {
        connectionPool.query(
            `SELECT * FROM Stats where id_user=?`,
            [id],
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }
                return callBack(null, results);
            }
        );
    },
}