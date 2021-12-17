const {create} = require('./categories.service');

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
    
}