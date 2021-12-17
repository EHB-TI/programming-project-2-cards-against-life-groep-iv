const {create, get} = require('./rooms.service');

module.exports = {
    createUser: (req, res) => {
        const body = req.body;
        create(body, (err, results)=>{
            if(err){
                console.log(err);
                return res.status(500).json({
                    succes: 0,
                    message: "Database connection error!"
                });
            }
            return res.status(200).json({
                succes: 1,
                data: results
            });
        })
    },

    get: (req, res) => {
        get((err, results) => {
          if (err) {
            console.log(err);
            return;
          }
          return res.json({
            success: 1,
            data: results
          });
        });
      },

    
}