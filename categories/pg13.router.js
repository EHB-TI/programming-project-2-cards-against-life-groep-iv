//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllPG13, getPG13ByID} = require("./pg13.controller");


router.get("/", getAllPG13);
router.get("/:id", getPG13ByID);

module.exports = router;