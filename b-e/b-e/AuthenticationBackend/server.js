const express = require('express');
const app = express();
const keys = require('./config/keys.js');
const bodyParser = require('body-parser')

// parse application/x-www-form-urlencoded
app.use(bodyParser.urlencoded({ extended: false }))

//Setting Up DB
const mongoose = require('mongoose');
mongoose.connect(keys.mongoURI, {useNewUrlParser: true, useUnifiedTopology: true});

//Setting Up DB Models
require('./model/Account');

//Setting Up Routes
require('./routes/authenticationRoutes')(app);

app.listen(keys.port, () => {
    console.log("Listening On " + keys.port);
})
