const {
    getAllPG13,
    getPG13ByID
} = require("./pg13.service");

module.exports = {
    getAllPG13: (req, res) => {
        getAllPG13((err, results) => {
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
                PG13: {
                    answers: results[0],
                    questions: results[1]
                }
            });
        });
    },
    getPG13ByID: (req, res) => {
        const id = req.params.id;
        getPG13ByID(id, (err, results) => {
            if (err) {
                console.log(err);
                return;
            }
            if (!results[0].length > 0 || !results[1].length > 0) {
                return res.json({
                    success: 0,
                    message: "No items found with id: " + id
                });
            }
            return res.json({
                success: 1,
                PG13: {
                    answers: results[0],
                    questions: results[1]
                }
            });
        });
    },
}