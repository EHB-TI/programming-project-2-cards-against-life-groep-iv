//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    getAllUsers: (callBack) => {
        connectionPool.query(
            'SELECT id_user,username,level FROM Users;',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }

                return callBack(null, results);
            }
        )
    },
    getUserByID: (id, callBack) => {
        connectionPool.query(
            `SELECT id_user,username,level FROM Users where id_user=?`,
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