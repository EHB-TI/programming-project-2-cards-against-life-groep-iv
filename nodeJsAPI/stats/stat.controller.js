//Author: De Vogel Ryan
const {
    getAllStats,
    getStatByUserID
} = require("./stat.service");

module.exports = {
    getAllStats: (req, res) => {
        getAllStats((err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results) {//
                return res.json({
                    success: 0,
                    message: "Record not Found"
                });
            }
            return res.json({
                success: 1,
                Stats: results
            });
        });
    },
    getStatByUserID: (req, res) => {
        const id = req.params.id;
        getStatByUserID(id, (err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results.length > 0) {
                return res.json({
                    success: 0,
                    message: "No stats found with userID: " + id
                });
            }
            return res.json({
                success: 1,
                Stat: results
            });
        });
    },
}