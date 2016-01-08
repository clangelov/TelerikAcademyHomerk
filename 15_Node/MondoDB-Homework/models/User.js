var mongoose = require('mongoose');

module.exports.init = function () {

    var userSchema = mongoose.Schema({
        user: {
            type: String,
            require: '{PATH} is required',
            unique: true,
            maxlength: 100,
            minlenght: 5 },
        pass: {
            type: String,
            require: '{PATH} is required',
            minlenght: 6,
            match: /[A-z0-9]+/}
    });

    var User = mongoose.model('User', userSchema);
    console.log('User model created...');
};

