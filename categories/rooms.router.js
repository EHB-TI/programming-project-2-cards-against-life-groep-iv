const {createUser, get} = require('./rooms.controller');
const router = require('express').Router();

router.post('/', createUser);
router.get('/', get);

module.exports = router;