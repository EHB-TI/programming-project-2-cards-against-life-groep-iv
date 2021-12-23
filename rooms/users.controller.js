//Author: De Vogel Ryan
const {
    GetAllRoomUsers,
    GetAllRoomUsersById,
    AddUsersToRoom
} = require("./users.service");

module.exports = {
    GetAllRoomUsers: (req, res) => {
        GetAllRoomUsers((err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results) {
                return res.json({
                    success: 0,
                    message: "Record not Found"
                });
            }
            return res.json({
                success: 1,
                RoomsUsers: results
            });
        });
    },
    GetAllRoomUsersById: (req, res) => {
        const id = req.params.id;
        GetAllRoomUsersById(id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "error"
                });
            }
            if (!results.length > 0) { //check if the response if not empty(or in other words the room with that id exists)
                return res.json({
                    success: 0,
                    message: "No rooms found with id: " + id
                });
            }
            return res.json({
                success: 1,
                RoomUsers: results[0]
            });
        });
    },
    AddUsersToRoom: (req, res) => {
        const body = req.body;
        AddUsersToRoom(body, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            if (!results) {
                return res.status(500).json({
                    success: 0,
                    message: "Duplicate key for value 'code'!"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        });
    },
}