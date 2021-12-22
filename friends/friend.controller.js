//Author: De Vogel Ryan
const {
    getAllfriends,
    getFriendByUserID
} = require("./friend.service");

module.exports = {
    getAllfriends: (req, res) => {
        getAllfriends((err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "error"
                });
            }
            if (!results) {
                return res.json({
                    success: 0,
                    message: "Record not Found"
                });
            }
            return res.json({
                success: 1,
                Friends: results
            });
        });
    },
    getFriendByUserID: (req, res) => {
        const id = req.params.id;
        getFriendByUserID(id, (err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results.length > 0) {
                return res.json({
                    success: 0,
                    message: "No users found with id: " + id
                });
            }
            return res.json({
                success: 1,
                Friend: results[0]
            });
        });
    },
}