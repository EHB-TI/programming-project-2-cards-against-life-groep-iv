const pool = require("../config/database");

module.exports = {
    create: (data, callback) => {
        pool.query(
            'INSERT INTO Room(id_room, id_user, id_code, open) VALUES (?,?,?,?)',
            [
                data.id_room,
                data.id_user,
                data.id_code,
                data.open
            ],
            (error, results, fields) => {
                if (error) {
                    return callback(error);
                }
                return callback(null, results);
            }
        )
    },
    get: callBack => {
        pool.query(
          `select * FROM Room`,
          [],
          (error, results, fields) => {
            if (error) {
              callBack(error);
            }
            return callBack(null, results);
          }
        );
      },
}