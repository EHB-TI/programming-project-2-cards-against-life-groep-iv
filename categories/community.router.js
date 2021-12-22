//Author: De Vogel Ryan
const router = require("express").Router();
const {getAllCommunity, getCommunityByID, createCommunity} = require("./community.controller");


router.get("/", getAllCommunity);
router.post("/", createCommunity);
router.get("/:id", getCommunityByID);

module.exports = router;