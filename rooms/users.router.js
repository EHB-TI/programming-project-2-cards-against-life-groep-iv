//Author: De Vogel Ryan
const router = require("express").Router();
const {GetAllRoomUsers, GetAllRoomUsersById, AddUsersToRoom} = require("./users.controller");


router.get("/", GetAllRoomUsers);
router.post("/", AddUsersToRoom);
router.get("/:id", GetAllRoomUsersById);

module.exports = router;