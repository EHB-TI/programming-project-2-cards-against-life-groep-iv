//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllStats, getStatByUserID} = require("./stat.controller");


router.get("/", getAllStats);
router.get("/:id", getStatByUserID);

module.exports = router;