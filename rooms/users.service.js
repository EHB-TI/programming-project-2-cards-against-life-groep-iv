//Author: De Vogel Ryan
const connectionPool = require("../config/database");

module.exports = {
    GetAllRoomUsers: (callBack) => {
        connectionPool.query(
            'SELECT * FROM RoomUsers;',
            (error, results, fields) => {
                if (error) {
                    callBack(error);
                }

                return callBack(null, results);
            }
        )
    },
    GetAllRoomUsersById: (id, callBack) => {
        connectionPool.query(
            `SELECT * FROM RoomUsers where room_id=?`,
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
    AddUsersToRoom: (data, callBack) => {
        connectionPool.query(
            'INSERT INTO RoomUsers(room_id,user_id) VALUES (?,?)',
            [
                data.room_id,
                data.user_id
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