//Author: De Vogel Ryan
const {
    getAllR,
    getRByID
} = require("./r.service");

module.exports = {
    getAllR: (req, res) => {
        getAllR((err, results) => {
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
                R: {
                    answers: results[0],
                    questions: results[1]
                }
            });
        });
    },
    getRByID: (req, res) => {
        const id = req.params.id;
        getRByID(id, (err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results[0].length > 0 || !results[1].length > 0) {
                return res.json({
                    success: 0,
                    message: "No cards found with id: " + id
                });
            }
            return res.json({
                success: 1,
                R: {
                    answers: results[0],
                    questions: results[1]
                }
            });
        });
    },
}