//Author: De Vogel Ryan
const {
    getAllUsers,
    getUserByID
} = require("./user.service");

module.exports = {
    getAllUsers: (req, res) => {
        getAllUsers((err, results) => {
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
                Users: results
            });
        });
    },
    getUserByID: (req, res) => {
        const id = req.params.id;
        getUserByID(id, (err, results) => {
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
                    User: results[0]
            });
        });
    },
}