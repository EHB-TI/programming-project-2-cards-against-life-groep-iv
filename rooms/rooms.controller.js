//Author: De Vogel Ryan
const {
    getAllRooms,
    getRoomByID,
    createRoom
} = require("./rooms.service");

module.exports = {
    getAllRooms: (req, res) => {
        getAllRooms((err, results) => {
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
                    Rooms: results
            });
        });
    },
    getRoomByID: (req, res) => {
        const id = req.params.id;
        getRoomByID(id, (err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results.length > 0) {//check if the response if not empty(or in other words the room with that id exists)
                return res.json({
                    success: 0,
                    message: "No rooms found with id: " + id
                });
            }
            return res.json({
                success: 1,
                    Room: results[0]
            });
        });
    },
    createRoom: (req, res) => {
        const body = req.body;
        createRoom(body, (err, results) => {
          if (err) {
            console.log(err);
            return res.status(500).json({
              success: 0,
              message: "Database connection errror"
            });
          }
          return res.status(200).json({
            success: 1,
            data: results
          });
        });
      },
}