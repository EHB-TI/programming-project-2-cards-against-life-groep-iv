const {
  getAllPG, getPGByID
} = require("./pg.service");

module.exports = {
  getAllPG: (req, res) => {
    getAllPG((err, results) => {
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
        PG:{
          answers: results[0],
          questions: results[1]
        }});
    });
  },
  getPGByID: (req, res) => {
    const id = req.params.id;
    getPGByID(id, (err, results) => {
      if (err) {
        console.log(err);
        return;
      }
      if (!results[0].length > 0 || !results[1].length >0) {
        return res.json({
          success: 0,
          message: "No items found with id: " + id
        });
      }
      return res.json({
        success: 1,
        PG:{
        answers: results[0],
        questions: results[1]
        }});
    });
  },
}