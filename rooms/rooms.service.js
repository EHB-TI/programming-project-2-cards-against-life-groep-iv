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
    //This is for checking for a duplicate value
    //source: https://www.titanwolf.org/Network/q/73afed53-5543-4927-bd51-8d4bb977ecf0/y
    createRoom: (data, callBack) => {
        connectionPool.query('SELECT * FROM Rooms WHERE code = ?',
            [data.code],
            function (err, rows) {
                if (err) {
                    callBack(err);
                }
                if (!rows.length) {
                    connectionPool.query(
                        'INSERT INTO Rooms(id_user,code,cat,pub,open) VALUES (?,?,?,?,?)',
                        [
                            data.id_user,
                            data.code,
                            data.cat,
                            data.pub,
                            data.open
                        ],
                        (error, results, fields) => {
                            if (error) {
                                callBack(error);
                            }

                            return callBack(null, results);
                        }
                    )
                }
                else {
                    console.log("A user posted a duplicate key");
                    callBack(err);
                }
            })
    },
}