const {createUser} = require('./categories.controller');
const router = require('express').Router();

router.post('/', createUser);

module.exports = router;