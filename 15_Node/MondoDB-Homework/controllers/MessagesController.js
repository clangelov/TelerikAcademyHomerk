var mongoose = require('mongoose');
var User = mongoose.model('User');
var Message = mongoose.model('Message');

module.exports = {
    sendMessage: function (messageData) {
        if (!messageData) {
            return console.log('Message is empty');
        }

        var newMessage = new Message({
            from: messageData.from,
            to: messageData.to,
            text: messageData.text
        });

        newMessage.save(function (error, message) {
            if (error) {
                return console.log(error);
            }

            console.log(message.from + ' said to ' + message.to + ' : ' + message.text);
        });
    },
    getMessages: function (queryData, callback) {
        Message.find()
            .or([{from: queryData.with, to: queryData.and}, {from: queryData.and, to: queryData.with}])
            .exec(function (error, messages) {
                if (error) {
                    console.log('Cannot find messages: ' + error);
                    return;
                }

                callback(messages);
            });
    }
};
