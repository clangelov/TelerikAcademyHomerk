var Phone = require('mongoose').model('Phone');

module.exports = {
    getAll: function (req, res, next) {

        Phone.find({})
            .exec(function (err, phones) {
                if (err) {
                    console.log('Get all users failed: ' + err);
                    return;
                } else {
                    res.render('../views/phones/phones', {
                        phone: phones,
                        currentUser: req.user
                    });

                }
            })
    },
    getDetails: function (req, res) {
        if (req.isAuthenticated()) {
            Phone.find({_id: req.params.id}).exec(function (err, phone) {
                if (err) {
                    console.log('Get phone failed: ' + err);
                    return;
                }

                res.render('../views/phones/phone-details', {phone: phone[0], currentUser: req.user});
            });
        }
        else {
            res.send({reason: 'You do not have permissions!'})
        }
    }
};