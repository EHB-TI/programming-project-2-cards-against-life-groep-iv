//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    getAllRooms: (callBack) => {
        connectionPool.query(
            'SELECT * FROM Rooms;',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }

                return callBack(null, results);
            }
        )
    },
    getRoomByID: (id, callBack) => {
        connectionPool.query(
            `SELECT * FROM Rooms where id=?`,
            [id],
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }
                return callBack(null, results);
            }
        );
    },
    createRoom: (data, callBack) => {
        connectionPool.query(
            'INSERT INTO Rooms(id_user,code,open) VALUES (?,?,?)',
            [
                data.id_user,
                data.code,
                data.open
            ],
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }

                return callBack(null, results);
            }
        )
    },
}