//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllPG, getPGByID} = require("./pg.controller");


router.get("/", getAllPG);
router.get("/:id", getPGByID);

module.exports = router;