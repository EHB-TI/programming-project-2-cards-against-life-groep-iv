//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllUsers, getUserByID} = require("./user.controller");


router.get("/", getAllUsers);
router.get("/:id", getUserByID);

module.exports = router;