var mongoose = require('mongoose');
var User = mongoose.model('User');

module.exports = {
    registerUser: function (userData) {
        
    if(!userData) {
        return console.log('Invalid data');
    }
        
    var newUser = new User({
        user: userData.user,
        pass: userData.pass
    });

    newUser.save(function (error, user) {
        if (error) {
            return console.log(error);
        }

        console.log('New user registered: ' + JSON.stringify(user));
    })}
};