var mongoose = require('mongoose');

module.exports.init = function () {
    var messagesSchema = new mongoose.Schema({
        text: {
            type: String,
            required: '{PATH} is required',
            maxlength: 1000,
            minlenght: 1  },
        from : {
            type: String
        },
        to: {
            type: String
        }
    });

    Message = mongoose.model('Message', messagesSchema);
    console.log('Message model created...');
};