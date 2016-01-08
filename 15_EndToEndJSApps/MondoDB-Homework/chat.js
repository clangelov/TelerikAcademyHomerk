require('./models/User');
require('./models/Message');

var UsersController = require('./controllers/UsersController'),
    MessagesController = require('./controllers/MessagesController');

module.exports = {
    registerUser: function (user) {
        UsersController.registerUser(user);
    },
    sendMessage: function (messageData) {
        MessagesController.sendMessage(messageData);
    },
    getMessages: function (messageData) {
        MessagesController.getMessages(messageData, function (messages) {
            console.log(messages.join('\n\n'));
        });
    }
};