//Author: De Vogel Ryan
const {
    getAllCommunity, getCommunityByID, createCommunity
  } = require("./community.service");
  
  module.exports = {
    getAllCommunity: (req, res) => {
        getAllCommunity((err, results) => {
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
          Community:{
            answers: results[0],
            questions: results[1]
          }});
      });
    },
    getCommunityByID: (req, res) => {
      const id = req.params.id;
      getCommunityByID(id, (err, results) => {
        if (err) {
          console.log(err);
          return;
        }
        if (!results[0].length > 0 || !results[1].length >0) { //check if the response if not empty(or in other words the room with that id exists).
          //we SELECT 2 tables so that's why results[0] and results[1] is used. They each hold the response of a different table.
          return res.json({
            success: 0,
            message: "No cards found with id: " + id
          });
        }
        return res.json({
          success: 1,
          Community:{
          answers: results[0],
          questions: results[1]
          }});
      });
    },
    createCommunity: (req, res) => {
        const body = req.body;
        createCommunity(body, (err, results) => {
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