var path = require('path');

module.exports = function (app) {

    app.get('/favicon.ico', function (req, res) {
        res.sendFile(path.resolve(__dirname + '/../../favicon.ico'))
    });

    app.get('/Home', function(req, res) {
        res.render('../views/home/home');
    });

    app.get('/Phones', function(req, res) {
        res.render('../views/phones/phones');
    });

    app.get('/Tablets', function(req, res) {
        res.render('../views/tablets/tablets');
    });

    app.get('/Wearables', function(req, res) {
        res.render('../views/wearables/wearables');
    });

    app.get('*', function(req, res) {
        res.redirect('/Home');
    });
};