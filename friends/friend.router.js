//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllfriends, getFriendByUserID} = require("./friend.controller");


router.get("/", getAllfriends);
router.get("/:id", getFriendByUserID);

module.exports = router;