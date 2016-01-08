var express = require('express');

var env = process.env.NODE_ENV || 'development';

var app = express();
var config = require('./config/config')[env];

require('./config/mongoose')(config);

app.listen(config.port);
console.log("Server running on port: " + config.port);

var chatDb = require('./chat');
//inserts a new user records into the DB
chatDb.registerUser({user: 'DonchoMinkov', pass: '123456q'});
chatDb.registerUser({user: 'NikolayKostov', pass: '123456q'});
//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'I sent you a second message!'
});
//returns an array with all messages between two users
console.log('Some delay before gathering the messages');
setTimeout(function () {
    chatDb.getMessages({
        with: 'NikolayKostov',
        and: 'DonchoMinkov'
    });
}, 1000);
