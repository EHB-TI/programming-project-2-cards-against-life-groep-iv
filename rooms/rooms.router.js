//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllRooms, getRoomByID, createRoom} = require("./rooms.controller");


router.get("/", getAllRooms);
router.post("/", createRoom);
router.get("/:id", getRoomByID);

module.exports = router;