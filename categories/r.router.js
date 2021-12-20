//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllR, getRByID} = require("./r.controller");


router.get("/", getAllR);
router.get("/:id", getRByID);

module.exports = router;